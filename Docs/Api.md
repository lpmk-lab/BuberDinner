
# Buber Diner API

Table of Contents[up to date]
- [Buber Dinner Api](#buber-diner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login]
            - [Login Request](#login-request)
            - [Login Response](#login-response)


## Auth


### Register
```Json
POST {{host}}/auth/register
```

#### Register Request
```Json
{
 
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Psw@1234"

  
}
```
#### Register Response
```Js
200 Ok
```
```Json
{
  "id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Psw@1234",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"

  
}
```

### Login
```Json
POST {{host}}/auth/login
```
#### Login Request

```Json
{

  "email": "john.doe@example.com",
  "password": "Psw@1234"

  
}
```

#### Login Response
```Js
200 Ok
```
```Json
{
  "id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "Firstname": "John",
  "LastName": "Doe",
  "email": "john.doe@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
}
```