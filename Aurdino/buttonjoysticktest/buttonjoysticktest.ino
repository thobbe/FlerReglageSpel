//joystick
int ledpin = 5;
int An = 0; //X values from joystick
int Ae = 1; //Y values from joystick
int At = 2;
int xVal = 0;
int yVal = 0;
int kVal = 0;
const int initValue[2] = {0,0}; 
int currentValue[3] = {0,0,0}; 
//button 
int pushButton = 2;
int buttonState = 0;
void setup() {

//joystick
pinMode(ledpin,OUTPUT);
//button 
pinMode(pushButton,INPUT);
 
Serial.begin(9600); //Starts serial at 9600 baud
}

int treatValue(int data){
  return((data*9/1024-4)/4);
}

void loop() {
  //joystick
  xVal = analogRead(An); //sets the X value
  delay(10);
  yVal = analogRead(Ae); //sets the Y value
   delay(10);

  xVal = treatValue(xVal);
  yVal = treatValue(yVal);
  
  //currentValue[0] = xVal;
  //currentValue[1] = yVal;

 /* if(xVal < 0)
  {
    currentValue[0] = -1; 
  }
   else if(xVal > 0)
  {
   currentValue[0] = 1; 
  }
    if(yVal < 0)
  {
    currentValue[1] = -1; 
  }
    else if(yVal > 0)
  {
    currentValue[1] = 1; 
  }
   if (xVal == 0 && yVal == 0)
  {
      currentValue[0] = 0;
      currentValue[1] = 0;
  }*/
  digitalWrite(pushButton, LOW);
 //button 
  buttonState = digitalRead(pushButton);
 
  delay(10); // kan en delay här påverka joysticken? 

  


   currentValue[0] = xVal;
   currentValue[1] = yVal; 


  //Serial.print(xVal);
  //Serial.print(yVal);

 // currentValue[2] = buttonState;

    for(int i=0; i<2; ++i)
    {
      Serial.print(currentValue[i]);
      if(i == 2)
      {
        Serial.println(' ');
      }
    }

  Serial.println(buttonState);
 
    


}
