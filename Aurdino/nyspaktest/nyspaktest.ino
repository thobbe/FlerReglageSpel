// vilken pin som knapparna sitter på 
const int b1 = 2;
const int b2 = 3;
int const declaration_length = 14;
int declaration[declaration_length];

// varibler som kommer representera in signal till arduinon 
int b1s = 0;
//int b2s = 0;

void setup() {
// sätter alla pins till att ta in signaler  
 pinMode(b1, INPUT);
 pinMode(b2, OUTPUT);
 Serial.begin(9600);
}

void loop() {
// läser av varje switch/knapp 
  b1s = digitalRead(b1);
  //b2s = digitalRead(b2);
  delay(5);
//om en knapp blir tryckt.
  if (b1s == HIGH)
  {
    declaration[0] =1;
    digitalWrite(b2, HIGH);
    //Serial.print(1);
    //Serial.write(1);
    //Serial.flush();
  }
 
  else 
  {
    declaration[0] =0;
    digitalWrite(b2, LOW);
    //Serial.print(0);
    //Serial.write(0);
    //Serial.flush();
  }
  declaration[1] =0;  
  declaration[2] =0;
  declaration[3] =0;
  declaration[4] =0;
  declaration[5] =0;
  declaration[6] =0;
  declaration[7] =0;
  declaration[8] =0;
  declaration[9] =0;
  declaration[10] =0;   //Left
  declaration[11] =0;
  declaration[12] =0;
  declaration[13] =0;
  

  for(int i = 0; i < declaration_length; i++){
    Serial.print(declaration[i]);
  }
 //Serial.print("1 1 1 1 1");
  Serial.println(' ');
  Serial.flush();

}
