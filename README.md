# Project .NET Framework

* Naam: Sami Filjak
* Studentennummer: 015467153
* Academiejaar: 23-24
* Klasgroep: INF201
* Onderwerp: Player agent 1 - * Football Player * - * Football Team 

## Sprint 3

### Beide zoekcriteria ingevuld
```sql
SELECT "p"."Id", "p"."BirthDate", "p"."Name", "p"."Position", "p"."Salary"
FROM "Players" AS "p"
WHERE (@__name_0 = '' OR instr("p"."Name", @__name_0) > 0) AND "p"."BirthDate" = @__birth_Value_1
```

### Enkel zoeken op naam

```sql
SELECT "p"."Id", "p"."BirthDate", "p"."Name", "p"."Position", "p"."Salary"
FROM "Players" AS "p"
WHERE @__name_0 = '' OR instr("p"."Name", @__name_0) > 0
```

### Enkel zoeken op geboortedatum
```sql
SELECT "p"."Id", "p"."BirthDate", "p"."Name", "p"."Position", "p"."Salary"
FROM "Players" AS "p"
WHERE "p"."BirthDate" = @__birth_Value_0
```

### Beide zoekcriteria leeg
```sql
SELECT "p"."Id", "p"."BirthDate", "p"."Name", "p"."Position", "p"."Salary"
FROM "Players" AS "p"
```

## Sprint 4

```mermaid
classDiagram
    class Agent {
      +String Name
      +DateTime BirthDate
      +String? PhoneNumber
      +int Id
      +ICollection~Player~ Players
    }

    class Player {
      +String Name
      +DateTime BirthDate
      +Position Position
      +double Salary
      +ICollection~Team~ Teams
      +int Id
      +ICollection~Contract~ Contracts
      +Agent Agent
      +Validate(ValidationContext) IEnumerable~ValidationResult~
    }

    class Team {
      +String Name
      +DateTime Founded
      +String Country
      +ICollection~Player~ Players
      +int Id
      +ICollection~Contract~ Contracts
    }

    class Contract {
      +Player Player
      +Team Team
      +DateTime StartDate
      +DateTime EndDate
      +int Id
    }

    class Position {
      <<enumeration>>
      Keeper
      Defender
      Midfielder
      Attacker
    }

    Agent "1" -- "*" Player : has
    Player "1" -- "*" Contract : has
    Team "1" -- "*" Contract : has
```