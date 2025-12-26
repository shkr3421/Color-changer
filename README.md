Below are all 15 answers rewritten with HTML-only code + clear explanation for each, exactly as asked.
(No JavaScript used anywhere.)


---

1. Mandatory Multi-Field Validation

HTML

<form>
  <input type="text" name="username" required minlength="5" placeholder="Username">
  <input type="email" name="email" required placeholder="Email">
  <input type="password" name="password" required minlength="8" placeholder="Password">
  <button type="submit">Register</button>
</form>

Explanation

required ensures no field is left empty

minlength enforces minimum characters

Browser blocks form submission until all conditions are met



---

2. Conditional Validation

HTML

<form>
  <label>
    <input type="checkbox" name="subscribe">
    Subscribe to newsletter
  </label>

  <input type="email" name="email" placeholder="Email">
</form>

Explanation
HTML5 cannot conditionally apply required based on checkbox state.
Attributes are static and cannot react to other fields.
➡️ JavaScript is required for true conditional validation.


---

3. Numeric Range Edge Cases

HTML

<input type="number" name="age" min="18" max="60" step="1" required>

Explanation

0 → rejected (below min)

61 → rejected (above max)

18.5 → rejected because step="1" allows only integers
HTML validates this on form submission.



---

4. Pattern Matching Challenge

HTML

<input type="tel"
       name="phone"
       pattern="[789][0-9]{9}"
       required
       placeholder="Mobile Number">

Explanation

Must start with 7, 8, or 9

Must contain exactly 10 digits

1234567890 fails because it starts with 1



---

5. Email Format Traps

HTML

<input type="email" name="email" required>

Explanation

user@@example.com ❌ (invalid syntax)

user@com ❌ (missing domain structure)

user@example.co.in ✅ (valid email)
HTML uses a basic RFC-based email pattern, not full verification.



---

6. Textarea Minimum Length

HTML

<textarea name="comments" minlength="50" required></textarea>

Explanation

Exactly 50 characters → accepted

49 characters → rejected
Validation occurs on submission, not while typing.



---

7. Password Complexity

HTML

<input type="password"
       name="password"
       minlength="8"
       pattern="(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).*"
       required>

Explanation

pattern enforces uppercase, lowercase, number, special character

HTML cannot explain which rule failed

Complex feedback requires JavaScript



---

8. Real-Time Error Handling

HTML

<input type="number" name="quantity" min="1" max="10" required>

Explanation
HTML validates only on submit or blur, not real-time.
If user types 15 and deletes it, HTML does nothing immediately.
JavaScript is needed for live validation feedback.


---

9. Multiple Inputs With Same Name

HTML

<form>
  <input type="checkbox" name="hobby" value="music" required> Music
  <input type="checkbox" name="hobby" value="reading"> Reading
  <input type="checkbox" name="hobby" value="travel"> Travel
</form>

Explanation
Applying required to one checkbox in the group ensures
at least one option must be selected.


---

10. Custom Validation Message

HTML

<input type="email"
       name="email"
       required
       title="Enter your official email">

Explanation
HTML alone cannot fully customize messages.
Browser shows title text as the error message fallback.


---

11. URL Input Validation

HTML

<input type="url" name="website" required>

Explanation

www.example.com ❌ (missing protocol)

https://www.example.com ✅
HTML requires a valid URL scheme.



---

12. Handling Optional Fields

HTML

<textarea name="comment" minlength="20"
          placeholder="Optional (min 20 chars if filled)">
</textarea>

Explanation

Empty field → valid

Less than 20 characters → invalid
HTML enforces rules only when input exists.



---

13. Cross-Field Validation

HTML

<input type="password" name="password" required>
<input type="password" name="confirm_password" required>

Explanation
HTML cannot compare values between fields.
Matching passwords requires JavaScript or backend validation.


---

14. Date Input Validation

HTML

<input type="date" name="event_date" min="2025-12-26" required>

Explanation

Dates before today → rejected

Even manually typed invalid dates are blocked
HTML enforces min strictly.



---

15. Error Handling UX

HTML

<form novalidate>
  <input type="email" required>
  <span class="error">Invalid email</span>
</form>

Explanation
HTML cannot control where errors appear.
novalidate disables browser popups.
Custom inline errors require JavaScript logic.
