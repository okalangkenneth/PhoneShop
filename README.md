# A Microservice-based E-commerce Gateway with Identity Server and Azure Service Bus Integration

## Table of Contents.
1. [Introduction](#introduction)
2. [System Architecture](#system-architecture)
3. [Non-Functional Requirements](#non-functional-requirements)

## Introduction

The demand for scalable and secure e-commerce platforms has increased, making it essential for businesses to have robust backend systems. This backend project aims to create an e-commerce application using microservices architecture, Identity Server, and Azure Service Bus integration. The microservices architecture will employ the N-Layer implementation with the Repository Pattern to break the application into independent components that can be easily managed and scaled. The application will use both Async and Sync communication between the microservices and will use Entity Framework Core with a SQL Server database for data management.

This project emphasizes the importance of the backend architecture and focuses on building a solid foundation for a successful e-commerce platform. Identity Server will handle user authentication, authorization, and management, while Azure Service Bus will enable messaging and communication between the microservices. The e-commerce application will provide features such as product catalog management, shopping cart functionality, and order management.

The project will prioritize non-functional requirements such as performance, security, availability, and reliability, ensuring that the backend system can handle high traffic and provide a seamless user experience. By the end of the project, we aim to develop a robust and scalable e-commerce application that meets modern business requirements and showcases the benefits of microservices architecture, Identity Server, Azure Service Bus, N-Layer implementation, Repository Pattern, Async and Sync communication, and Entity Framework Core with a SQL Server database.

In summary, this backend project is a comprehensive solution for businesses of all sizes looking to build a scalable and secure e-commerce platform.

## System Architecture.

![image](https://user-images.githubusercontent.com/68539411/223565684-642f3c07-fdc7-4881-b000-70360f859577.png)

This diagram shows the different components of the e-commerce application and how they communicate with each other. Each of the microservices will have its own database. The microservices communicate with each other through RESTful APIs or message queues. The dotted lines indicate asynchronous while the solid lines indicate synchronous communication. The Identity Server provides a centralized authentication and authorization mechanism for the microservices ensuring that the application is secure and compliant. Azure Service Bus enables messaging and communication between the microservices, ensuring that the application is highly available and reliable.
The microservices will be designed using the N-Layer implementation with the Repository Pattern, ensuring that the business logic and data access layers are separated.

## Non-Functional Requirements.
The Non-Functional Requirements section describes the quality attributes that the system must possess in addition to its functional requirements. These attributes are critical to ensuring that the system performs optimally, is reliable, and is easy to maintain. In this section, we describe the non-functional requirements for our e-commerce application, including performance, security, scalability, reliability, maintainability, usability, testability, accessibility, and technology requirements. These requirements will be used to guide the design, development, and testing of the system and ensure that it meets the expectations of its users.

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
