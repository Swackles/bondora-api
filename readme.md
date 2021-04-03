# Bondora developer home assignment

This is my api portion of developer home assaignment

## API description

### /api/equipment

#### GET /

Returns all available equipment

```json
[
    {
        "ID": 1,
        "Name": "Caterpillar bulldozer",
        "TypeID": 1
    },
    {
        "ID": 2,
        "Name": "KamAZ truck",
        "TypeID": 0
    },
    {
        "ID": 3,
        "Name": "Komatsu crane",
        "TypeID": 1
    }
]
```

#### GET /{id}

Returns equipment with id

```json
{
    "ID": 4,
    "Name": "Volvo steamroller",
    "TypeID": 0
}
```

### /api/equipmenttype

#### GET/{id}

Returns equipment type with id

```json
{
    "LoyaltyPoints": 2,
    "OneTimeFee": 100.0,
    "PremiumFee": 60.0,
    "RegularFee": 40.0
}
```

### /api/invoice

Post data must be a dictionary with key being the equipment id and value being the days said equipment is rented

```json
{
    "1": 10,
    "4": 4
}
```

Equipment with id is rented for 10 days and equipment with id 4 is rented for 4 days.

#### POST /

Returns the invoice

```json
{
    "Items": [
        {
            "Equipment": {
                "ID": 1,
                "Name": "Caterpillar bulldozer",
                "TypeID": 1
            },
            "DaysRented": 10,
            "LoyaltyPoints": 2,
            "Price": 700.0
        },
        {
            "Equipment": {
                "ID": 4,
                "Name": "Volvo steamroller",
                "TypeID": 0
            },
            "DaysRented": 4,
            "LoyaltyPoints": 1,
            "Price": 420.0
        }
    ],
    "LoyaltyPoints":14,
    "Sum": 1120.0
}
```

#### POST /print

Returns what needs to be printed as string
