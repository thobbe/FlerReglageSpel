// vilken pin som knapparna sitter på 
const int b1 = 2;
//const int b2 = 3;


// varibler som kommer representera in signal till arduinon 
int b1s = 0;
//int b2s = 0;

void setup() {
// sätter alla pins till att ta in signaler  
 pinMode(b1, INPUT);
//pinMode(b2, INPUT);
 Serial.begin(9600);
}

void loop() {
// läser av varje switch/knapp 
  b1s = digitalRead(b1);
  //b2s = digitalRead(b2);
  delay(50);

//om en knapp blir tryckt.
  if (b1s == HIGH)
  {
    Serial.print(1);
    //Serial.write(1);
    //Serial.flush();
  }
 
  else 
  {
    Serial.print(0);
    //Serial.write(0);
    //Serial.flush();
  }
  /* if (b2s == LOW)
  {
    Serial.print(1);
    //Serial.write(1);
    //Serial.flush();
  }else 
  {
    Serial.print(0);
    //Serial.write(0);
    //Serial.flush();
  }*/
  Serial.println(' ');

}
