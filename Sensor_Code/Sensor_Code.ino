// Cyber Glove Team

#include <Wire.h>
#include <SparkFun_ADS1015_Arduino_Library.h>
#include <SparkFun_BNO080_Arduino_Library.h>

const int numFingers = 5;
int fingerValues[numFingers] = {0, 0, 0, 0, 0};
// thumb(0), index(1), middle(2), ring(3), pinky(4)

// Thumb analog flex sensor
int thumbSensor = A0; // Thumb

// Flex sensor controllers
ADS1015 pinkySensor;  // Pinky/Ring
ADS1015 indexSensor;  // Middle/Index

// flex sensor smoothing
const int numReadings = 10;
int fingerReadings[numFingers][numReadings];
int fingerReadIndicies[numFingers] = {0, 0, 0, 0, 0};
int fingerTotals[numFingers] = {0, 0, 0, 0, 0};
int fingerAverages[numFingers] = {0, 0, 0, 0, 0};

String fingerAverageStrings[numFingers];

BNO080 myIMU1; //Open I2C ADR jumper - goes to address 0x4B
BNO080 myIMU2; //Closed I2C ADR jumper - goes to address 0x4A

void setup(void)
{
  // Initialize I2C
  Wire.begin();
  Wire.setClock(400000); //Increase I2C data rate to 400kHz
  // Initialize Serial Communication (over USB)
  Serial.begin(9600);
  
  //Begin our finger controllers, change addresses as needed.
  if (indexSensor.begin(0x48) == false) 
  {
    while (1)
      Serial.println("Pinky not found. Check wiring.");
  }
  if (pinkySensor.begin(0x49) == false) 
  {
    while (1)
      Serial.println("Index not found. Check wiring.");
  }

  // Gain of 2/3 to work well with flex glove board voltage swings (default is gain of 2)
  pinkySensor.setGain(ADS1015_CONFIG_PGA_TWOTHIRDS);
  indexSensor.setGain(ADS1015_CONFIG_PGA_TWOTHIRDS);

  // Initialize readings to 0
  for (int thisReading = 0; thisReading < numReadings; thisReading++)
  {
    for (int finger = 0; finger < 5; finger++)
    {
      fingerReadings[finger][thisReading] = 0;
    }
  }
  
  //Start 2 sensors
  if (myIMU1.begin(0x4B) == false)
  {
    Serial.println("First BNO080 not detected with I2C ADR jumper open. Check your jumpers and the hookup guide. Freezing...");
    while(1);
  }

  if (myIMU2.begin(0x4A) == false)
  {
    Serial.println("Second BNO080 not detected with I2C ADR jumper closed. Check your jumpers and the hookup guide. Freezing...");
    while(1);
  }
  
  myIMU1.enableRotationVector(50); //Send data update every 50ms
  myIMU2.enableRotationVector(50); //Send data update every 50ms
}

void loop(void)
{
  //Look for reports from the IMU
  if (myIMU1.dataAvailable() == true && myIMU2.dataAvailable() == true)
  {
    // Read flex sensor
    int thumbPos = analogRead(thumbSensor);
    // Map sensor val from 0 to 1
    fingerValues[0] = map(thumbPos, 450, 100, 0, 1000);
  
    // get smoothed data
    fingerAverages[0] = getMovingAverage(fingerTotals[0], fingerReadings[0], fingerReadIndicies[0], fingerValues[0]);
  
    // Read flex controllers
    int i = 0;
    for (int finger = 1; finger < 3; finger++) {
      fingerValues[finger] = indexSensor.getAnalogData(i);
      fingerValues[finger + 2] = pinkySensor.getAnalogData(i);
      
      fingerValues[finger] = map(fingerValues[finger], 1100, 800, 0, 1000);
      fingerValues[finger + 2] = map(fingerValues[finger + 2], 930, 800, 0, 1000);
      
      fingerAverages[finger] = getMovingAverage(fingerTotals[finger], fingerReadings[finger], fingerReadIndicies[finger], fingerValues[finger]);
      fingerAverages[finger + 2] = getMovingAverage(fingerTotals[finger + 2], fingerReadings[finger + 2], fingerReadIndicies[finger + 2], fingerValues[finger + 2]);
      
      i++;
    }
  
    // Cast to string
    for (int finger = 0; finger < numFingers; finger++)
    {
      fingerAverageStrings[finger] = String(fingerAverages[finger]);
    }
  
    // Print to Serial
    Serial.print(fingerAverageStrings[0]);
    Serial.print(",");
    Serial.print(fingerAverageStrings[1]);
    Serial.print(",");
    Serial.print(fingerAverageStrings[2]);
    Serial.print(",");
    Serial.print(fingerAverageStrings[3]);
    Serial.print(",");
    Serial.print(fingerAverageStrings[4]);
    Serial.print("#");


    int quatI1 = myIMU1.getQuatI() * 1000;
    int quatJ1 = myIMU1.getQuatJ() * 1000;
    int quatK1 = myIMU1.getQuatK() * 1000;
    int quatReal1 = myIMU1.getQuatReal() * 1000;

    int quatI2 = myIMU2.getQuatI() * 1000;
    int quatJ2 = myIMU2.getQuatJ() * 1000;
    int quatK2 = myIMU2.getQuatK() * 1000;
    int quatReal2 = myIMU2.getQuatReal() * 1000;
  
    // IMU Dummy Data
    Serial.print(quatI1);
    Serial.print(",");
    Serial.print(quatJ1);
    Serial.print(",");
    Serial.print(quatK1);
    Serial.print(",");
    Serial.print(quatReal1);
    Serial.print(";");
    Serial.print("0");
    Serial.print(",");
    Serial.print("0");
    Serial.print(",");
    Serial.print("0");
    Serial.print("#");
    Serial.print(quatI2);
    Serial.print(",");
    Serial.print(quatJ2);
    Serial.print(",");
    Serial.print(quatK2);
    Serial.print(",");
    Serial.print(quatReal2);
    Serial.print(";");
    Serial.print("0");
    Serial.print(",");
    Serial.print("0");
    Serial.print(",");
    Serial.print("0");
  
    // Finish line (linebreak)
    Serial.println();
  
  //  delay(20); // prevents buffer overflow, but also limits unity framerate if not async
  }
}


// function to calculate moving average (smooths sensor data)
int getMovingAverage(int &total, int (&readings)[numReadings], int &readIndex, int &value)
{
  int average = -1;

  // subtract the last reading:
  total = total - readings[readIndex];
  // read from the sensor:
  readings[readIndex] = value;
  // add the reading to the total:
  total = total + readings[readIndex];
  // advance to the next position in the array:
  readIndex = readIndex + 1;

  // if we're at the end of the array...
  if (readIndex >= numReadings) {
    // ...wrap around to the beginning:
    readIndex = 0;
  }

  // calculate the average:
  average = total / numReadings;

  return average;
}
