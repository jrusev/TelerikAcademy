# Software design patterns

## Creational patterns

* __Abstract factory__ : Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
* __Builder__ : Separate the construction of a complex object from its representation, allowing the same construction process to create various representations.
* __Factory method__ : Define an interface for creating a single object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses (dependency injection[15]).
* __Lazy initialization__ : Tactic of delaying the creation of an object, the calculation of a value, or some other expensive process until the first time it is needed. This pattern appears in the GoF catalog as "virtual proxy", an implementation strategy for the Proxy pattern.
* __Prototype__ : Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
* __Singleton__ : Ensure a class has only one instance, and provide a global point of access to it.
	
## Structural patterns

* __Adapter (Wrapper)__ : Convert the interface of a class into another interface clients expect. An adapter lets classes work together that could not otherwise because of incompatible interfaces. The enterprise integration pattern equivalent is the translator.
* __Bridge__ : Decouple an abstraction from its implementation allowing the two to vary independently.
* __Composite__ : Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
* __Decorator__ : Attach additional responsibilities to an object dynamically keeping the same interface. Decorators provide a flexible alternative to subclassing for extending functionality.
* __Facade__ : Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.
* __Flyweight__ : Use sharing to support large numbers of similar objects efficiently.
* __Proxy__ : Provide a surrogate or placeholder for another object to control access to it.
 	
## Behavioral patterns

* __Chain of responsibility__ : Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
* __Command__ : Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
* __Interpreter__ : Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.
* __Iterator__ : Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
* __Mediator__ : Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
* __Memento__ : Without violating encapsulation, capture and externalize an object's internal state allowing the object to be restored to this state later.
* __Observer__ : Define a one-to-many dependency between objects where a state change in one object results in all its dependents being notified and updated automatically.
* __State__ : Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
* __Strategy__ : Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
* __Template method__ : Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
* __Visitor__ : Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.
