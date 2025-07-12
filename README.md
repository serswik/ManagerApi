## Testing (Postman or Equivalent)

API functionality was verified using Swagger UI. Below are the test scenarios with example requests and actual responses:

1. Creating a valid user (POST /users)  
Request Body:  
{
  "fullName": "John Doe",
  "email": "john.doe@example.com",
  "dateOfBirth": "1990-01-01"
}  
Response body:  
{
  "Id": 1,
  "FullName": "John Doe",
  "Email": "john.doe@example.com",
  "DateOfBirth": "1990-01-01T00:00:00"
} 
Status Code: 201 Created

<img width="842" height="285" alt="image" src="https://github.com/user-attachments/assets/9c0d3806-8208-4522-84c9-1325c63d59e9" />

2. Getting the list of users (GET /users)  
Actual Response (after creating one user):  
[
  {
  "Id": 1,
    "FullName": "John Doe",
    "Email": "john.doe@example.com",
    "DateOfBirth": "1990-01-01T00:00:00"
  }
]
Status Code: 200 OK

<img width="847" height="264" alt="image" src="https://github.com/user-attachments/assets/b77348ce-0787-4ec5-b54e-948fc82b8f43" />

3. Creating a user with invalid email (POST /users)  
Request Body:  
{
  "fullName": "Jane Doe",
  "email": "not-an-email",
  "dateOfBirth": "1990-05-20"
}  
Actual Response:  
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Email": [
      "The Email field is not a valid e-mail address.",
      "Email is not valid"
    ]
  },
  "traceId": "generated-trace-id-here"
}
Status Code: 400 Bad Request

<img width="842" height="368" alt="image" src="https://github.com/user-attachments/assets/d169f38b-f970-4ecc-8166-b1afd9d7f621" />

4. Creating a user with future date of birth (POST /users)  
Request Body:  
{
  "fullName": "Future Person",
  "email": "future@example.com",
  "dateOfBirth": "2100-01-01"
}  
Actual Response:  
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "DateOfBirth": [
      "Date of birth cannot be in the future"
    ]
  },
  "traceId": "generated-trace-id-here"
} 
Status Code: 400 Bad Request

<img width="863" height="356" alt="image" src="https://github.com/user-attachments/assets/bdb68c70-311d-4806-b2a2-0705b9fcf8df" />
