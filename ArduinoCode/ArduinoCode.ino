const int SensorPin = A0;
int rollingAverage;


int latestValues[10];
byte currentArrayIndex = 0;


unsigned long startMillis;
unsigned long currentMillis;
const unsigned long period = 200; // Delay between each write

void setup() {
  Serial.begin(9600);
  startMillis=millis();
}

void loop() {
  currentMillis = millis();
  if(currentMillis - startMillis >= period){
    latestValues[currentArrayIndex] = analogRead(SensorPin);
    delay(10);

    currentArrayIndex += 1;
    if(currentArrayIndex > 9){
      currentArrayIndex = 0;
    }

    if(latestValues[9] == 0){
      //Stops it from writing anything before the array is filled with values
      return;
    }

    int sumOfArray = 0;
    for(int i=0; i<10; i++){
      sumOfArray += latestValues[i];
    }
    rollingAverage = round(sumOfArray/10);
    
    Serial.print(rollingAverage);
    Serial.print("\n");
  
    startMillis = currentMillis;
  }
}
