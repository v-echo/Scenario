## Implementation 1

Here we showcase 2 different implementations of the core "business logic":
1. A divider that takes the requirements and implements them as they are
2. A more generic service that can take a variable number of dividers as parameters. **You can see a 2nd version of this, stateless and async, in Implementation 3**.

#### Usage
Build and run the projects (requires Visual Studio 2022 and .NET 6). 

### Note
The `SharedLibrary` project is used by the other implementations, which should explains why there are classes and interfaces not referenced in this implementation.