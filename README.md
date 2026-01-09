1. let vs const – Bug in Production
Why the error happens
const does not allow reassignment. If a variable is declared using const and later you try to assign a new value to it, JavaScript throws a runtime error. In a dashboard application, if the logged-in user switches accounts without reloading the page and the role needs to be updated, using const for the role variable causes an error.
Copy code
Js
const userRole = "admin";
userRole = "user"; // TypeError: Assignment to constant variable
Correct refactor
Use const for values that never change and let for values that need reassignment.
Copy code
Js
const user = {
  id: 1,
  name: "Shashank"
};

let userRole = "admin";

function switchAccount(newRole) {
  userRole = newRole;
}
Rule of thumb: Use const by default and switch to let only when reassignment is required.
2. Block Scope Debugging Issue (var vs let)
Problem with var
When var is used inside a loop, it creates a single shared variable. As a result, all dynamically created buttons log the same index value (the final value of the loop).
Copy code
Js
for (var i = 0; i < 3; i++) {
  button.onclick = function () {
    console.log(i); // always logs 3
  };
}
Why let fixes the issue
let is block-scoped. Each iteration of the loop creates a new binding of i, so each button retains its correct index value.
Copy code
Js
for (let i = 0; i < 3; i++) {
  button.onclick = function () {
    console.log(i); // logs 0, 1, 2
  };
}
Internal behavior
var creates one shared variable across all iterations, while let creates a new variable binding for each iteration.
3. Error Handling in API Response
Crash reason
The API sometimes returns null, but the code assumes a valid object and tries to access deep properties, causing a runtime error.
Copy code
Js
response.data.user.name; // Cannot read properties of null
Handling using try...catch
Wrapping the access in a try...catch block prevents the application from crashing and allows graceful error handling.
Copy code
Js
try {
  const name = response.data.user.name;
  console.log(name);
} catch (error) {
  console.error("Invalid API response", error);
}
Safer modern approach
Optional chaining prevents errors by safely handling null or undefined values.
Copy code
Js
const name = response?.data?.user?.name ?? "Guest";
Browser debugging steps
Open DevTools, inspect the Network tab, check the API response structure, verify whether data or user is null, and log the response before accessing properties.
4. Custom Error for Business Logic
Business rule
Payment amount should never be zero or negative.
Throwing a custom error
A custom error can be thrown when invalid input is detected.
Copy code
Js
function processPayment(amount) {
  if (amount <= 0) {
    throw new Error("Payment amount must be greater than zero");
  }
  return "Payment successful";
}
Catching and displaying a user-friendly message
The error is caught and a clean message is shown without breaking the application flow.
Copy code
Js
try {
  processPayment(-100);
} catch (err) {
  alert(err.message);
}
5. Generators for Large Data Processing
Problem with normal loops
Processing a very large dataset at once can be slow and memory-intensive.
Copy code
Js
logs.forEach(log => process(log));
Using a generator function
Generators yield one item at a time, allowing efficient processing.
Copy code
Js
function* logProcessor(logs) {
  for (const log of logs) {
    yield log;
  }
}

for (const log of logProcessor(hugeLogs)) {
  process(log);
}
Why generators are better
They reduce memory usage, process data lazily, and are ideal for large datasets, logs, and streams.
6. Iterators in a Custom Object
Requirement
Enable iteration over a custom object using for...of.
Implementation using Symbol.iterator
Copy code
Js
const playlist = {
  songs: ["Song A", "Song B", "Song C"],
  [Symbol.iterator]() {
    let index = 0;
    return {
      next: () => {
        if (index < this.songs.length) {
          return { value: this.songs[index++], done: false };
        }
        return { done: true };
      }
    };
  }
};

for (const song of playlist) {
  console.log(song);
}
This allows the object to behave like an array during iteration.
7. Import / Export Debugging Scenario
Common mistake
Confusing default exports with named exports leads to undefined imports.
Copy code
Js
// utils.js
export default function helper() {}

// app.js
import { helper } from "./utils"; // undefined
Correct usage for default export
Copy code
Js
import helper from "./utils";
Named export example
Copy code
Js
// utils.js
export function helper() {}

// app.js
import { helper } from "./utils";
Debug checklist
Verify named vs default export usage, check file paths, ensure correct spelling, and log the imported value.
8. Functions vs Classes Decision
When to choose a class
A class is suitable when an object has state and behavior, requires multiple instances, and has a clear lifecycle.
ES6 class structure
Copy code
Js
class Notification {
  constructor(message) {
    this.message = message;
    this.read = false;
  }

  markAsRead() {
    this.read = true;
  }
}

const note = new Notification("New message");
note.markAsRead();
Classes provide cleaner structure and better scalability for such use cases.
9. Map, Filter, Reduce – Performance Case
Requirements
Filter completed orders, calculate total revenue, and format the output.
Copy code
Js
const result = orders
  .filter(order => order.status === "completed")
  .map(order => ({
    id: order.id,
    amount: order.amount
  }))
  .reduce(
    (acc, order) => {
      acc.total += order.amount;
      acc.orders.push(order);
      return acc;
    },
    { total: 0, orders: [] }
  );
Why this approach is better
It is declarative, readable, avoids manual loops, minimizes side effects, and is easier to debug and maintain.
10. Arrow Functions and this Bug
Problem with normal functions
A regular function has its own this, which depends on how it is called, often leading to undefined in event handlers.
Copy code
Js
button.onclick = function () {
  console.log(this.name);
};
Arrow function solution
Copy code
Js
button.onclick = () => {
  console.log(this.name);
};
Why it works
Arrow functions do not have their own this. They lexically bind this from the surrounding scope, ensuring correct context inside class methods and callbacks.
