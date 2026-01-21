MODULES & PACKAGES (5 Questions)
1. Structuring a large application using packages and sub-packages & role of __init__.py
For a large application with authentication, database, and logging, the project should be structured using logical separation of concerns.
Example structure:
Copy code

my_app/
│
├── auth/
│   ├── __init__.py
│   ├── login.py
│   ├── permissions.py
│
├── database/
│   ├── __init__.py
│   ├── connection.py
│   ├── models.py
│
├── logging/
│   ├── __init__.py
│   ├── logger.py
│
├── utils/
│   ├── __init__.py
│   ├── helpers.py
│
└── main.py
Each package represents a major feature, and sub-packages break that feature into manageable modules.
Role of __init__.py:
Marks a directory as a Python package.
Controls what gets exposed when importing the package.
Can run initialization code (e.g., setting up configs).
Helps define a public API using __all__.
Example:
Copy code
Python
# auth/__init__.py
from .login import authenticate_user
Now users can do:
Copy code
Python
from auth import authenticate_user
2. Script runs directly but fails with ModuleNotFoundError when imported
Possible reasons:
Python cannot find the module in sys.path.
Relative imports are incorrect.
Script is executed from a different working directory.
Package is missing __init__.py.
Fixes:
Run the script using python -m package.module instead of directly.
Use absolute imports instead of relative ones.
Ensure the project root is in PYTHONPATH.
Add __init__.py files where needed.
Example fix:
Copy code
Python
from my_app.utils.helpers import format_date
instead of:
Copy code
Python
import helpers
3. Sharing common utility functions across multiple projects
Best approach is to create a custom reusable module.
Steps:
Create a separate folder:
Copy code

common_utils/
├── __init__.py
├── string_utils.py
├── date_utils.py
Convert it into a package and install it locally:
Copy code
Bash
pip install -e .
Import in any project:
Copy code
Python
from common_utils.string_utils import clean_text
Benefits:
Single source of truth
Easier updates
Cleaner architecture
Professional, scalable approach
4. Avoiding name conflicts when importing functions with the same name
Suppose:
Copy code
Python
math_utils.add()
string_utils.add()
Solutions:
Option 1: Import modules
Copy code
Python
import math_utils
import string_utils

math_utils.add()
string_utils.add()
Option 2: Alias imports
Copy code
Python
from math_utils import add as math_add
from string_utils import add as string_add
Option 3: Avoid wildcard imports
Copy code
Python
from module import *
This is discouraged because it increases ambiguity.
5. Lazy importing to improve startup performance
Lazy importing means importing modules only when needed, not at program startup.
Example:
Copy code
Python
def generate_report():
    import pandas
    import matplotlib
Benefits:
Faster startup time
Lower memory usage
Avoid loading heavy modules unnecessarily
When to use:
Large libraries (ML, plotting, DB clients)
Optional features
CLI tools with many commands
Avoid lazy imports if the module is required globally or affects program correctness.
GENERATORS (5 Questions)
1. Why generators are better than lists for a 10GB file
Generators:
Load one item at a time
Use constant memory
Process data sequentially
Example:
Copy code
Python
def read_logs(file):
    for line in file:
        yield line
Lists would attempt to load the entire file into memory, causing memory exhaustion. Generators allow streaming large files safely and efficiently.
2. Safely implementing an infinite timestamp generator
Copy code
Python
import time

def timestamp_generator():
    while True:
        yield time.time()
        time.sleep(1)
Safety measures:
Use consumer-side conditions to stop iteration
Avoid unbounded resource usage
Combine with itertools.islice() if needed
3. How Python remembers generator state
Python stores the generator’s:
Local variables
Instruction pointer
Execution stack
Each yield pauses execution, and the next call resumes exactly after the last yield.
Internally, generators use a frame object that preserves execution context.
4. Stopping a generator midway
Ways to stop:
Use break inside generator
Raise StopIteration
Let function return naturally
Example:
Copy code
Python
def gen():
    for i in range(10):
        if i == 5:
            return
        yield i
Internally:
Python raises StopIteration
Generator is marked as exhausted
Further next() calls fail
5. Generator expression vs list comprehension in streaming
List comprehension:
Copy code
Python
data = [process(x) for x in stream]
Generator expression:
Copy code
Python
data = (process(x) for x in stream)
Choice: Generator expression
Why:
Processes data on demand
Lower memory usage
Ideal for real-time streaming and pipelines
Prevents memory spikes
FILE HANDLING (5 Questions)
1. Ensuring logs are saved even if program crashes
Use:
Append mode (a)
Immediate flushing
Logging module
Example:
Copy code
Python
with open("log.txt", "a", buffering=1) as f:
    f.write("message\n")
Or:
Copy code
Python
logging.basicConfig(filename="app.log", level=logging.INFO)
2. Multiple processes reading the same file
Issues:
Race conditions
Incomplete reads
File pointer conflicts (for writes)
Prevention:
Use file locks (fcntl, portalocker)
Read-only access for readers
Atomic writes using temp files
3. Efficient CSV read, clean, and write
Use streaming:
Copy code
Python
import csv

with open("input.csv") as src, open("output.csv", "w", newline="") as dst:
    reader = csv.reader(src)
    writer = csv.writer(dst)
    for row in reader:
        cleaned = clean(row)
        writer.writerow(cleaned)
Benefits:
No full file loading
Efficient memory usage
Scales to large datasets
4. Ensuring sensitive files are closed
Use context managers:
Copy code
Python
with open("secret.txt") as f:
    data = f.read()
This guarantees closure even if:
An exception occurs
Function returns early
Avoid manual open() / close() unless absolutely necessary.
5. Ensuring file closure during exceptions
Use with or try-finally:
Copy code
Python
try:
    f = open("data.txt")
    process(f)
finally:
    f.close()
Preferred:
Copy code
Python
with open("data.txt") as f:
    process(f)
This is exception-safe and clean.
DECORATORS (5 Questions)
1. Logging execution time using decorators
Decorators allow adding behavior without modifying function code.
Copy code
Python
def timing(func):
    def wrapper(*args, **kwargs):
        start = time.time()
        result = func(*args, **kwargs)
        print(time.time() - start)
        return result
    return wrapper
Apply to any function easily:
Copy code
Python
@timing
def task():
    pass
2. Authentication enforcement using decorators
Copy code
Python
def login_required(func):
    def wrapper(user, *args, **kwargs):
        if not user.is_authenticated:
            raise PermissionError
        return func(user, *args, **kwargs)
    return wrapper
This centralizes security logic and avoids repeated checks.
3. Order of execution with multiple decorators
Decorators are applied bottom to top.
Copy code
Python
@A
@B
def func():
    pass
Execution:
func = A(B(func))
B runs first, then A
Order matters for:
Authentication
Logging
Caching
Error handling
4. Fixing lost function name and docstring
Use functools.wraps:
Copy code
Python
from functools import wraps

def decorator(func):
    @wraps(func)
    def wrapper(*args, **kwargs):
        return func(*args, **kwargs)
    return wrapper
This preserves:
__name__
__doc__
Debugging and introspection support
5. Decorators with arguments
Normal decorator:
Copy code
Python
@decorator
def func():
Decorator with arguments requires three layers:
Copy code
Python
def retry(times):
    def decorator(func):
        def wrapper(*args, **kwargs):
            for _ in range(times):
                try:
                    return func(*args, **kwargs)
                except:
                    pass
        return wrapper
    return decorator
Used as:
Copy code
Python
@retry(3)
def api_call():
Difference:
Extra outer function handles parameters
Enables configurable behavior
