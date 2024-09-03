# Requirements List

1. Clear Order Summary
   The order confirmation email should provide the customer with a clear and well-structured summary of their order, including items, prices, and delivery address.

2. Integration of Transaction Details
   Insert detailed transaction information such as order number, payment details, and delivery status in the order confirmation email.

3. Personalized Thank You Message
   Add a personalized thank you message to strengthen customer loyalty and show appreciation to the customer.

4. Link to Customer Support
   Include links to customer support options in case of questions or issues regarding the order.

5. Printable Version Option
   Provide an option to download or print the order confirmation as a printable version.

6. Real-Time Delivery Status Updates
   Continuous real-time updates of the delivery status so customers can track the progress of their order.

7. Accurate Delivery Time Information
   Provide accurate delivery times and dates to give customers a clear idea of when their order will be delivered.

8. Automated Status Updates
   Automatically notify customers of status changes such as order preparation, shipment, and delivery.

9. Link to Tracking Service
   Integrate links to external tracking services so customers can track their orders directly through third-party services.

10. Notifications of Delays
    Send notifications to customers when there are delivery delays, and provide clear information on the reasons for the delay.

# Architecture

## Database

Clustered Microsoft SQL Server.

## Backend

.NET Core Web API

- Web API implementation
- Controller
- OpenAPI/Swagger definition
- Entity Framework Core for DB connection
- Modularized Monolith

## Frontend

Angular Frontend

- Connection to Backend via HttpClient

## Output Format

| ID                            | Requirement Title        | Requirement Description | Module                         |
| ----------------------------- | ------------------------ | ----------------------- | ------------------------------ |
| Unique ID for the requirement | Title of the requirement | Brief description       | Module(s) for this requirement |

Sort the list by module and based on the chronological sequence (from searching for items to completing the purchase).
