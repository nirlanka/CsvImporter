Acme SalesImporter
==================

Import a store orders list from a given source and push it to a given destination.

Supports:
- CSV -> MySQL
- extensible

## Usage

Either,
- run the binary in the command line with `./Acme.SalesImporter -f ./path/file.csv`.
- place the CSV as `sales.csv` next to the `Acme.SalesImporter` binary and just run `./Acme.SalesImporter`.

## Assumptions

### The application is run manually through the CLI 

(otherwise it can use HangFire to run this as a background job at desired times or frequencies).

### The CSV file is always relatively small

If it were very large, extracting from the file and pushing to the database should be done in surges (i.e. broken into multiple sets of `ServiceOrders` and saved separately) to avoid memory consumption. But that would be fundementally different from the current validations, as validations (such as `UNIQUE`) will only happen inside each set.

## Decisions

### Use CodeFirst approach to database mapping and creation

If the schema is created in the database, the app only takes care of adding data and validating. If the schema doesn't exist, `Database.EnsureCreated();` will create it at the beginning. This is possible because the schema is closely recreated in code in the class `EntityMapper`.

### Use CsvHelper

I first attempted to use TinyCsvParser, which is quite fast. But it can't handle rows that are broken into multiple lines. That was the major reason I switched to CsvHelper. Both supported quoted strings and custom delimiters. Another benefit with CsvHelper is that it can map cells by headers, without us having to identify the order of columns.

### Use `appsettings.json`

This was based on ease of configurability, so that no compilation is needed to change database connection. The next step would be to enable setting the connection string from the CLI.

### Using data I/O through interfaces

Having interfaces for I/O work makes it easily extensible. Without changing a lot of code, you can create a class that inherits that interface (e.g. `IStoreOrderReader` or `StoreContext`) and implement a whole different way of reading or exporting data. Then, by creating a class that inherits `IServiceMapper`, you can add it to CLI handler as a new CLI option.

I didn't use interfaces for CLI handlers and Logger. I still made them easily modifiable by converging reused code into methods. The difference with this I/O is that it's less prone to change than reading and exporting store order data. Changing this would anyway require a new build of the app, which, of course can be now easily written by changing just two places (`Logger` class and the call to CLI handler in `Program` class).

### Custom exception and top-level exception handlers

This helps control all exceptions in a more abstract way. Any different implementation of data I/O can handle their own exceptions and pass them up with customized messages that will be handled in a common way.

## Concerns

### Given schema not supporting given input data

The CSV contains multiple records of different orders by the same customer. But the schema limits the `CUSOTOMER_ID` as `UNIQUE`, making all orders by the customer except the first invalid. 
In a general perspective, the data seems like a common possibility. Therefore, my assumption was that the schema was wrong. But we can also assume that the composite of `ORDER_ID`, `PRODUCT_ID`, `CUSTOMER_ID` should be `UNIQUE`. Therefore I added this constraint:

```sql
CREATE TABLE STORE_ORDER (
  -- ...
  ORDER_ID VARCHAR(20) NOT NULL,
  -- ...
  PRODUCT_ID VARCHAR(20) NOT NULL,
  -- ...
  CUSTOMER_ID VARCHAR(20) NOT NULL
);

ALTER TABLE STORE_ORDER 
  ADD CONSTRAINT unique_orderid_productid_customerid 
    UNIQUE (ORDER_ID, PRODUCT_ID, CUSTOMER_ID);
```