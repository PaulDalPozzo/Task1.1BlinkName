// C++ code
//

// timer parameters in milliseconds
const double INTERVAL_TIME = 128; //millis() returns between 0 and 255 (1s), happens between each dot and dash
const double DOT_TIME = INTERVAL_TIME; //0.1 seconds
const double DASH_TIME = INTERVAL_TIME*3; //3 times dot time
const double BETWEEN_LETTER_TIME = INTERVAL_TIME*3;
const double BETWEEN_WORD_TIME = INTERVAL_TIME; // is 7 times the interval, but I have excluded the 2 time between letters

// state setup
const int WAIT = 0, START = 1, BLINKING = 2;
const int END = 0, DOT = 1, DASH = 2, B_DOT_DASH = 3, B_LETTER = 4, B_WORD = 5;
int _state;
int _ledState = 0;
int _buttonState = 0;  // variable for reading the pushbutton status

// name to blink
char name[] = {'P', 'A', 'U', 'L'};
int intervals[211]; //large array size, can handle 30 characters of 4 dash/dots (including spaces and end value) 
int count = 0;
int lettersRemaining = 0;

// timer
double timer = 0;
unsigned long currentMillis = 0;
unsigned long previousMillis = 0;

// pin assignment
const int buttonPin = 2;  // the number of the pushbutton pin
const int ledPin = 13;    // the number of the LED pin

void setup() 
{
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin, INPUT);
  
  next(WAIT);
}

void loop()
{
  // read the state of the pushbutton value:
  _buttonState = digitalRead(buttonPin);
  
  currentMillis = millis() - previousMillis;
  if (currentMillis > INTERVAL_TIME + previousMillis)
  {
    previousMillis = currentMillis;
    tick();
    return;
  }
  
  if (_buttonState == HIGH) buttonPressed();
}

void tick()
{
  timer -= INTERVAL_TIME;
  switch(_state)
  {
    case WAIT:
      return;
    case START:
      return;
    case BLINKING:
      blinking();
      return;
    default:
      next(WAIT);
  }
}

void buttonPressed()
{
  switch(_state)
  {
    case WAIT:
      next(START);
      return;
    case START:
      return;
    case BLINKING:
      next(START);
      return;
  }
}

void next(int newState)
{
  _state = newState;
  switch(_state)
  {
    case WAIT:
      // turn LED off:
      digitalWrite(ledPin, LOW);
      return;
    case START:
      nameSetup();// set up name to be blinked
      next(BLINKING);
      return;
    case BLINKING:
      return;
  }
}

void nameSetup()
{
  count = 0;
  
  for (int c = 0; c < sizeof(name); c++)
  {
  	switch(name[c])
    {
      case 'A': //A = dot dash
        if (count + 3 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'B': //B = dash dot dot dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'C': //C = dash dot dash dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'D': //D = dash dot dot
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'E': //E = dot
        if (count + 1 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
        }
      	break;
      case 'F': //F = dot dot dash dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'G': //G = dash dash dot
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'H': //H = dot dot dot dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'I': //I = dot dot
        if (count + 3 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'J': //J = dot dash dash dash
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'K': //K = dash dot dash
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'L': //L = dot dash dot dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'M': //M = dash dash
        if (count + 3 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'N': //N = dash dot
        if (count + 3 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'O': //O = dash dash dash
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'P': //P = dot dash dash dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'Q': //Q = dash dash dot dash
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'R': //R = dot dash dot
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'S': //S = dot dot dot
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case 'T': //T = dash
        if (count + 1 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
        }
      	break;
      case 'U': //U = dot dot dash
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'V': //V = dot dot dot dash
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'W': //W = dot dash dash
        if (count + 5 < sizeof(intervals) - 1)
        {
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'X': //X = dash dot dot dash
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'Y': //Y = dash dot dash dash
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
        }
      	break;
      case 'Z': //Z = dash dash dot dot
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DASH;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
          intervals[count++] = B_DOT_DASH;
          intervals[count++] = DOT;
        }
      	break;
      case ' ': //Space = 7 intervals
        if (count + 7 < sizeof(intervals) - 1)
        {
          intervals[count++] = B_WORD;
        }
      	break;
    }
    
    if (c < sizeof(name)-1) intervals[count++] = B_LETTER;
  }
  
  intervals[count++] = END;
  lettersRemaining = count;
}

void blinking()
{
  if (timer > 0)return; //if time of blink is not complete, skip code below
  
  int nextLetter = count - lettersRemaining;
  lettersRemaining--;//reduce count of letters left
  
  switch(intervals[nextLetter])
  {
    case END:
      count = 0;
      next(WAIT);
      return;
    case DOT:
      digitalWrite(ledPin, HIGH);// turn LED on
      timer = DOT_TIME;
      return;
    case DASH:
      digitalWrite(ledPin, HIGH);// turn LED on
      timer = DASH_TIME;
      return;
    case B_DOT_DASH:
      digitalWrite(ledPin, LOW);// turn LED off
      timer = INTERVAL_TIME;
      return;
    case B_LETTER:
      digitalWrite(ledPin, LOW);// turn LED off
      timer = BETWEEN_LETTER_TIME;
      return;
    case B_WORD:
      digitalWrite(ledPin, LOW);// turn LED off
      timer = BETWEEN_WORD_TIME;
      return;
  }
}
