#include <Ultrasonic.h>

#define TRIGGER_PIN  12  //verde
#define ECHO_PIN     13 //amarelo

#define TRIGGER_PIN2  6  //verde
#define ECHO_PIN2     7 //amarelo


Ultrasonic ultrasonic(TRIGGER_PIN, ECHO_PIN);
Ultrasonic ultrasonic2(TRIGGER_PIN2, ECHO_PIN2);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  //pinMode(13, OUTPUT);
  
}
 
void loop() {

 float cmMsec, inMsec,cmMsec2, inMsec2;
  long microsec = ultrasonic.timing();
  long microsec2 = ultrasonic2.timing();
  
  cmMsec = ultrasonic.convert(microsec, Ultrasonic::CM);
  inMsec = ultrasonic.convert(microsec, Ultrasonic::IN);
  cmMsec2 = ultrasonic2.convert(microsec2, Ultrasonic::CM);
  inMsec2 = ultrasonic2.convert(microsec2, Ultrasonic::IN);

//Serial.println(cmMsec); 
  //   Serial.println(cmMsec2); 
  if((cmMsec < 6.0) && cmMsec2>=6.0){
    Serial.println(cmMsec);
    Serial.println(cmMsec2); 
    Serial.println("------------- OK ------------");
    } else if((cmMsec >= 6.0)&&(cmMsec2 >= 6.0)){
            Serial.println(cmMsec);
    Serial.println(cmMsec2); 
    Serial.println("------------- I ------------");      
     //Serial.println("I");
     //Serial.println("I"+cmMsec+"-"+cmMsec2);
      } else if((cmMsec >= 6.0)&&(cmMsec2 <= 6.0)){
            Serial.println(cmMsec);
    Serial.println(cmMsec2); 
    Serial.println("------------- F ------------");
      //Serial.println("F"+cmMsec+"-"+cmMsec2);
     //Serial.println("F");
      }
  

}
