## Code smells

* Poor/improper names
* Rename folders, projects names and namespaces
* Long method
* Duplicated code
* Dead code 
* Large class
* Long parameter list (in/out/ref parameters)
* Regions
* Comments
* define variables just before first use
* Inconsistency
* Obscured intent
* Switch statement (use polymorphism)
* Indecent exposure
* Hidden temporal coupling 
* Hidden dependencies (new)
* Class depends on subclass
* Inappropriate static
* Conditional complexity
* Data class
* Oddball solution
* Required setup/teardown code (use factory)
* Temporary field (two methods share data)

# Refactoring

* Convert a data primitive to a class (e.g. money)
* Convert a set of type codes (constants) to enum
* Use higher abstraction (IEnumerable -> ICollection -> IList)
* Use properties, hide data 
* Extract data and validation logic into small class
* Poor man's inversion of control
* Use internal in library, it the app does not need to see it






