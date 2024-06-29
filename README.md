# Feedback Review System

## Project Description

The Feedback Review System is an application designed to collect, manage, and review customer feedback. This project utilizes various technologies to ensure efficient feedback processing and management, aiming to provide a streamlined experience for both customers and managers.

## Features

1. **Feedback Submission (Console App)**:
    - Customers can submit their feedback through a simple console application.
    - Feedback is stored in a centralized database for easy access and management.

2. **Feedback Management (ASP.NET Core MVC)**:
    - Managers can view all feedback submitted by customers.
    - Feedbacks are categorized into two sections: Pending and Reviewed.
    - Managers can change the status of feedback from "Pending" to "Reviewed".

3. **Feedback Status Update (SQL Trigger)**:
    - A SQL trigger is used to log changes in feedback status.
    - When feedback status is updated, the change is recorded in an audit table, capturing the old status, new status, and the time of change.

4. **Weekly Reminder (Hangfire)**:
    - A scheduled job using Hangfire sends weekly reminders to managers to review pending feedback.
    - Ensures timely review of customer feedback.

5. **Docker Deployment**:
    - The application is containerized using Docker, making it easy to deploy and scale.
    - Docker Compose is used to manage multi-container applications.

## Technologies Used

- **Console Application**: For feedback submission by customers.
- **ASP.NET Core MVC**: For managing and reviewing feedback.
- **Entity Framework Core**: For database operations.
- **SQL Server**: As the database management system.
- **SQL Triggers**: For auditing feedback status changes.
- **Hangfire**: For scheduling and managing background jobs.
- **Docker**: For containerizing the application.

## Database Schema

### Tables

#### Customers

| Column      | Data Type | Constraints            |
|-------------|-----------|------------------------|
| CustomerId  | int       | Primary Key, Identity  |
| Name        | nvarchar  | Not Null               |
| Email       | nvarchar  | Not Null               |

#### Feedbacks

| Column       | Data Type | Constraints            |
|--------------|-----------|------------------------|
| FeedbackId   | int       | Primary Key, Identity  |
| CustomerId   | int       | Foreign Key, Not Null  |
| FeedbackText | nvarchar  | Not Null               |
| Status       | nvarchar  | Not Null (Default 'Pending') |

#### FeedbackStatusAudit

| Column      | Data Type | Constraints            |
|-------------|-----------|------------------------|
| LogId       | int       | Primary Key, Identity  |
| FeedbackId  | int       | Foreign Key, Not Null  |
| LastStatus  | nvarchar  | Not Null               |
| NowStatus   | nvarchar  | Not Null               |
| TableName   | nvarchar  | Not Null               |
| ColumnName  | nvarchar  | Not Null               |
| Status      | nvarchar  | Not Null               |
| Created     | datetime  | Not Null, Default GETDATE() |
