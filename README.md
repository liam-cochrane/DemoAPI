An example of a modern .Net Core API which follows RESTful principles.

The solution has been separated into three different libraries to allow for a good separation between endpoint logic, and data retreival logic.

-Demo.API
This project contains all of the controllers within the API and ONLY Controllers! All of our controllers should be very dumb, their sole purpose is to receive API requests, and ask a Manager in the Domain to do any processing of Models. Should a manager throw an exception, this layer will handle the exception and process it to return an appropriate http status code with a message, if there is not one already provided.

-Domain
--Managers
This contains all of the Managers and Models required for taking a request from a Controller within the Demo.API project -> interacting with the database -> returning a model to the controller, or throwing an APPROPRIATE Exception.
--Models
Models are the objects which can be serialised as JSON that are used for communication with the API externally, and communication between the API project and the Domain.
Models can be used to provide basic validation of required attributes, for example checking that you are not attempting to set a required attribute as null, an a integer provided falls within a specific range, or an Email is formatted correctly as an Email. Regex attributes can be used to check an attribute meets a specific regex format, or custom attributes are better. You can also make a Model inherit IValidatableObject to programmatically check that the Model meets your needs, for example you could check: if attribute A has a value, then attribute B also requires a value.

When Unit Testing is implemented, this is the ideal layer for it to sit on.

-Mock.Data
This is a fake placeholder database which can allow us to perform queries on some mock data.
