alert( 0 == false ); // true
alert( '' == false ); // true
alert( 0 === false ); // false, because the types are different
// There also exists a “strict non-equality” operator !==, as an analogy for !=

alert( null === undefined ); // false
alert( null == undefined ); // true

// Strange result: null vs 0
alert( null > 0 );  // (1) false
alert( null == 0 ); // (2) false
alert( null >= 0 ); // (3) true

// The value undefined shouldn’t participate in comparisons at all

let age = prompt('How old are you?', 100);    
alert(`You are ${age} years old!`); // You are 100 years old!

// Boolean conversion
// A number 0, an empty string "", null, undefined and NaN become false

// Multiple ‘?’
let message = (age < 3) ? 'Hi, baby!' :
  (age < 18) ? 'Hello!' :
  (age < 100) ? 'Greetings!' :
  'What an unusual age!';
alert( message );

// Non-traditional use of ‘?’ --> not recommended
(company == 'Netscape') ?
   alert('Right!') : alert('Wrong.');
   
// Loops:
// No break/continue to the right side of ‘?’
(i > 5) ? alert(i) : continue; // continue not allowed here

// switch statement
let a = 2 + 2;
switch (a) {
  case 3:
    alert( 'Too small' );
  case 4:
    alert( 'Exactly!' );
  case 5:
    alert( 'Too big' );
  default:
    alert( "I don't know such values" );
}
// In the example above we’ll see sequential execution of last three alerts

// Functions:
// shadowing:
let userName = 'John';
function showMessage() {
  let userName = "Bob"; // declare a local variable
  let message = 'Hello, ' + userName; // Bob
  alert(message);
}
// the function will create and use its own userName
// functions create local copies of passed params
// if we call showMessage("Ann"); we get "Ann: undefined" or we can use default values:
function showMessage(from, text = "no text given") {
  alert( from + ": " + text );
}
// or
function showMessage(from, text = anotherFunction()) {
  // anotherFunction() only executed if no text given
  // its result becomes the value of text
}

//If a function does not return a value, it is the same as if it returns undefined:
function doNothing() { /* empty */ }
alert( doNothing() === undefined ); // true

// JavaScript assumes a semicolon after return
return// implicit ;
 (some + long + expression + or + whatever * f(a) + f(b))
 
// A function can return a value. If it doesn’t, then its result is undefined.

// another way to define function: function expression vs the clasic fucntion declaration
var avg = function (a, b){
      return (a + b)/2;
    }
 document.write(avg(18, 34));
 
 // JavaScript Objects:
 let user = {
  name: "John",
  age: 30,
  sayHi() {
    alert(this.name);
  }
};
user.sayHi(); // John
// The value of this is evaluated during the run-time. And it can be anything.
// For instance, the same function may have different “this” when called from different objects:
let user = { name: "John" };
let admin = { name: "Admin" };
function sayHi() {
  alert( this.name );
}

// use the same functions in two objects
user.f = sayHi;
admin.f = sayHi;

// these calls have different this
// "this" inside the function is the object "before the dot"
user.f(); // John  (this == user)
admin.f(); // Admin  (this == admin)
admin['f'](); // Admin (dot or square brackets access the method – doesn't matter)
/* The consequences of unbound this:
If you come from another programming language, then you are probably used to the idea of a "bound this", where methods defined in an object always have this referencing that object.
In JavaScript this is “free”, its value is evaluated at call-time and does not depend on where the method was declared, but rather on what’s the object “before the dot”.
The concept of run-time evaluated this has both pluses and minuses. On the one hand, a function can be reused for different objects. On the other hand, greater flexibility opens a place for mistakes.
Here our position is not to judge whether this language design decision is good or bad. We’ll understand how to work with it, how to get benefits and evade problems.*/


// ----
// Methods with primitives : There are 6 primitive types: string, number, boolean, symbol, null and undefined
// Primitives except null and undefined provide many helpful methods. We will study those in the upcoming chapters.
// Formally, these methods work via temporary objects, but JavaScript engines are well tuned to optimize that internally, so they are not expensive to call.

// strings with backticks allow us to embed any expression into the string, including function calls
function sum(a, b) {
  return a + b;
}
alert(`1 + 2 = ${sum(1, 2)}.`); // 1 + 2 = 3.

// Arrays
let fruits = ["Apple", "Orange", "Plum"];
alert( fruits.length ); // 3
// An array can store elements of any type
let arr = [ 'Apple', { name: 'John' }, true, function() { alert('hello'); } ];
// iterates over array elements
for (let fruit of fruits) {
  alert( fruit );
}

// JSON (JavaScript Object Notation) 
JSON.stringify to convert objects into JSON.
JSON.parse to convert JSON back into an object.

// Rest parameters ...
// A function can be called with any number of arguments, no matter how it is defined. Like here:
 function sum(a, b) {
  return a + b;
}
alert( sum(1, 2, 3, 4, 5) );
// The rest parameters can be mentioned in a function definition with three dots .... They literally mean “gather the remaining parameters into an array”.
// For instance, to gather all arguments into array args:
 function sumAll(...args) // args is the name for the array

// Closures
// Lexical Environment
/* In JavaScript, every running function, code block, and the script as a whole have an associated object known as the Lexical Environment.
 The Lexical Environment object consists of two parts:
 - Environment Record – an object that has all local variables as its properties (and some other information like the value of this).
 - A reference to the outer lexical environment, usually the one associated with the code lexically right outside of it (outside of the current curly brackets).
 So, a “variable” is just a property of the special internal object, Environment Record. “To get or change a variable” means “to get or change a property of the Lexical Environment”.
 */
 function makeCounter() {
  let count = 0;
  return function() {
    return count++;
  };
}
let counter1 = makeCounter();
let counter2 = makeCounter();

alert( counter1() ); // 0
alert( counter1() ); // 1
alert( counter1() ); // 2
/* When an outer variable is modified, it’s changed where it’s found. So count++ finds the outer variable and increases it in the Lexical Environment where it belongs. 
Like if we had let count = 1.
*/
alert( counter2() ); // 0 (independent)
// For every call to makeCounter() a new function Lexical Environment is created, with its own counter. So the resulting counter functions are independent.






 
