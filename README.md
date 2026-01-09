1. let vs const – Bug in Production
❌ Why the error happens
const does not allow reassignment.
If the logged-in user switches accounts and you try to update the role, JS throws:
TypeError: Assignment to constant variable
Copy code
Js
const userRole = "admin";
userRole = "user"; // ❌ Error
✅ Correct refactor
Use const for values that never change
Use let for values that will be reassigned
Copy code
Js
const user = {
  id: 1,
  name: "Shashank"
};

let userRole = "admin"; // can change later

function switchAccount(newRole) {
  userRole = newRole;
}
Rule of thumb:
Use const by default → switch to let only when reassignment is needed.
2. Block Scope Debugging Issue (var vs let)
❌ Problem with var
All buttons log the same index (last value).
Copy code
Js
for (var i = 0; i < 3; i++) {
  button.onclick = function () {
    console.log(i); // always 3
  };
}
✅ Why let fixes it
let is block-scoped, so each iteration gets its own i.
Copy code
Js
for (let i = 0; i < 3; i++) {
  button.onclick = function () {
    console.log(i); // 0, 1, 2
  };
}
🔍 Internally
var → one shared variable
let → new binding per loop iteration
3. Error Handling in API Response
❌ Crash reason
API returns null, but you access deep properties:
Copy code
Js
response.data.user.name // ❌ Cannot read properties of null
✅ Using try...catch
Copy code
Js
try {
  const name = response.data.user.name;
  console.log(name);
} catch (error) {
  console.error("Invalid API response", error);
}
✅ Safer modern approach
Copy code
Js
const name = response?.data?.user?.name ?? "Guest";
🔍 Browser debugging steps
Open DevTools → Network
Inspect API response
Check if data or user is null
Add console.log(response) before accessing properties
4. Custom Error for Business Logic
❌ Invalid business rule
Amount ≤ 0 should never be allowed.
✅ Throwing a custom error
Copy code
Js
function processPayment(amount) {
  if (amount <= 0) {
    throw new Error("Payment amount must be greater than zero");
  }
  return "Payment successful";
}
✅ Catching and showing user-friendly message
Copy code
Js
try {
  processPayment(-100);
} catch (err) {
  alert(err.message); // clean UI message
}
✔ App continues running
✔ Error is controlled
✔ User sees meaningful feedback
5. Generators for Large Data Processing
❌ Normal loop (memory heavy)
Copy code
Js
logs.forEach(log => process(log));
✅ Generator solution
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
🚀 Why generators are better
Processes one item at a time
No large memory usage
Ideal for streams, logs, files
6. Iterators in a Custom Object
Goal: make object work with for...of
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
✔ Enables native iteration
✔ Works like arrays
✔ Clean & reusable
7. Import / Export Debugging Scenario
❌ Common mistake
Copy code
Js
// utils.js
export default function helper() {}

// app.js
import { helper } from "./utils"; // ❌ undefined
✅ Correct usage
Copy code
Js
// Default export
import helper from "./utils";
Named export example
Copy code
Js
// utils.js
export function helper() {}

// app.js
import { helper } from "./utils";
🔍 Debug checklist
Named vs default mismatch
Correct file path
Exported symbol spelling
console.log(importedValue)
8. Functions vs Classes Decision
When to choose class
Object has state + behavior
Needs multiple instances
Clear lifecycle
✅ ES6 class structure
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
✔ Clean
✔ Scalable
✔ Real-world modeling
9. Map, Filter, Reduce – Performance Case
Task:
Completed orders
Total revenue
Formatted output
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
🚀 Why this is better
Declarative & readable
Avoids mutation
Easier debugging
Optimized engine execution
10. Arrow Functions & this Bug
❌ Normal function loses this
Copy code
Js
button.onclick = function () {
  console.log(this.name); // undefined
};
✅ Arrow function fix
Copy code
Js
button.onclick = () => {
  console.log(this.name);
};
🔍 Why it works
Normal function → this depends on caller
Arrow function → lexically binds this
this stays from surrounding class scope
