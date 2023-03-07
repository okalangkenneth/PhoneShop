# EcomGateway: A Microservice-based E-commerce Gateway with Identity Server and Azure Service Bus Integration

## Table of Contents.
1. [Introduction](#introduction)
2. [System Architecture](#system-architecture)

## Introduction

The demand for e-commerce platforms has increased, requiring businesses to have scalable and secure online shopping applications. This project aims to create an e-commerce application using a microservices architecture, Identity Server, and Azure Service Bus integration. The microservices architecture will employ the N-Layer implementation with the Repository Pattern to break the application into independent components that can be easily managed and scaled. The application will use both Async and Sync communication between the microservices and will use Entity Framework Core with a SQL Server database for data management.

Identity Server will handle user authentication, authorization, and management, while Azure Service Bus will enable messaging and communication between the microservices. The e-commerce application will provide features such as product catalog management, shopping cart functionality, and order management.

The project will address non-functional requirements such as performance, security, availability, and reliability. By the end of the project, we aim to develop a robust and scalable e-commerce application that meets modern business requirements.

Overall, this project will showcase the benefits of microservices architecture, Identity Server, Azure Service Bus, N-Layer implementation, Repository Pattern, Async and Sync communication, and Entity Framework Core with a SQL Server database. The e-commerce application will provide a comprehensive solution for businesses of all sizes.
## System Architecture.

![image](https://user-images.githubusercontent.com/68539411/223565684-642f3c07-fdc7-4881-b000-70360f859577.png)

This diagram shows the different components of the e-commerce application and how they communicate with each other. Each of the microservices will have its own database. The microservices communicate with each other through RESTful APIs or message queues. The dotted lines indicate asynchronous while the solid lines indicate synchronous communication. The Identity Server provides a centralized authentication and authorization mechanism for the microservices ensuring that the application is secure and compliant. Azure Service Bus enables messaging and communication between the microservices, ensuring that the application is highly available and reliable.
The microservices will be designed using the N-Layer implementation with the Repository Pattern, ensuring that the business logic and data access layers are separated.

Overview of the architecture and design of the application
Explanation of the design patterns used in the application
Description of the microservices and their roles in the application
Explanation of the data models and their relationships
## Technologies Used
List of the technologies used in the application
Explanation of why each technology was chosen
## Implementation
Description of the implementation process
Explanation of the coding standards and conventions used
Overview of the features implemented in the application
## Testing and Deployment
Description of the testing process used
Explanation of the tools used for testing and monitoring
Overview of the deployment process and infrastructure
## Conclusion
Summary of the project
Lessons learned and future improvements
Possible directions for further development
## Appendix
Code snippets and examples
List of resources used during the development of the project
Glossary of technical terms used in the project
