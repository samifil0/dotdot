using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.DAL.EF;

public static class DataSeeder
{
    public static void Seed(PlayerAgentDbContext context)
    {
        
      
        Team barcelona = new Team
        {
            Name = "FC Barcelona",
            Founded = new DateTime(1899, 11, 29),
            Country = "Spain",
            Contracts = new List<Contract>()
        };
        Team madrid = new Team
        {
            Name = "Real Madrid CF",
            Founded = new DateTime(1902, 03, 06),
            Country = "Spain",
            Contracts = new List<Contract>()
        };
        
        Team city = new Team
        {
            Name = "Manchester City",
            Founded = new DateTime(1880, 08, 12),
            Country = "England",
            Contracts = new List<Contract>()
        };
        Team liverpool = new Team
        {
            Name = "Liverpool",
            Founded = new DateTime(1892, 03, 15),
            Country = "England",
            Contracts = new List<Contract>()
        };
        Team psg = new Team
        {
            Name = "Paris Saint-Germain",
            Founded = new DateTime(1970, 08, 12),
            Country = "France",
            Contracts = new List<Contract>()
        };
        Team bayern = new Team
        {
            Name = "Bayern Munich",
            Founded = new DateTime(1900, 02, 27),
            Country = "Germany",
            Contracts = new List<Contract>()
        };
        Team leverkusen = new Team
        {
            Name = "FC Bayern Leverkusen",
            Founded = new DateTime(1904, 07, 01),
            Country = "Germany",
            Contracts = new List<Contract>()
        };
        Team roma = new Team
        {
            Name = "AS Roma",
            Founded = new DateTime(1927, 07, 22),
            Country = "Italy",
            Contracts = new List<Contract>()
        };
        Team atletico = new Team
        {
            Name = "Athletico Madrid",
            Founded = new DateTime(1903, 04, 26),
            Country = "Spain",
            Contracts = new List<Contract>()
        };
        Team napoli = new Team
        {
            Name = "Napoli",
            Founded = new DateTime(1926, 08, 01),
            Country = "Italy",
            Contracts = new List<Contract>()
        };
       
        Agent raiola = new Agent
        {
            Name = "Mino Raiola",
            PhoneNumber = "0499123456",
            BirthDate = new DateTime(1967, 11, 04),
            Players = new List<Player>()
        };
        
        Agent pogba = new Agent
        {
            Name = "Mathias Pogba",
            PhoneNumber = "0499123453",
            BirthDate = new DateTime(1990, 08, 19),
            Players = new List<Player>()
        };
        
        Agent mendy = new Agent
        {
            Name = "Yvan Mendy",
            PhoneNumber = "0499123454",
            BirthDate = new DateTime(1985, 08, 29),
            Players = new List<Player>()
        };
        
        Agent koulibalyAgent = new Agent
        {
            Name = "Bruno Satin",
            PhoneNumber = "0499123457",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent marquinhosAgent = new Agent
        {
            Name = "Giuliano Bertolucci",
            PhoneNumber = "0499123458",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent alissonAgent = new Agent
        {
            Name = "Ze Maria Neis",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent mendes = new Agent
        {
            Name = "Jorge Mendes",
            PhoneNumber = "0499123459",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent oblakAgent = new Agent
        {
            Name = "Miha Mlakar",
            PhoneNumber = "0499123460",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent dokuAgent = new Agent
        {
            Name = "Jacques Lichtenstein",
            PhoneNumber = "0499123461",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent courtoisAgent = new Agent
        {
            Name = "Christophe Henrotay",
            PhoneNumber = "0499123462",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent modricAgent = new Agent
        {
            Name = "Vlado Lemic",
            PhoneNumber = "0499123463",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        Agent vanDijkAgent = new Agent
        {
            Name = "Humphry Nijman",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
        
        Agent messiAgent = new Agent
        {
            Name = "Jorge Messi",
            BirthDate = new DateTime(1969, 01, 01),
            Players = new List<Player>()
        };
        
          Player doku = new Player
        {
            Name = "Jeremy Doku",
            Agent = dokuAgent,
            BirthDate = new DateTime(2002, 05, 27),
            Position = Position.Attacker,
            Salary = 25000,
            Contracts = new List<Contract>()
        };
        Player courtois = new Player
        {
            Name = "Thibaut Courtois",
            Agent = courtoisAgent,
            BirthDate = new DateTime(1992, 05, 11),
            Position = Position.Keeper,
            Salary = 90000,
            Contracts = new List<Contract>()
        };
        Player modric = new Player
        {
            Name = "Luka Modric",
            Agent = modricAgent,
            BirthDate = new DateTime(1985, 09, 09),
            Position = Position.Midfielder,
            Salary = 100000,
            Contracts = new List<Contract>()
        };
        Player vanDijk = new Player
        {
            Name = "Virgil Van Dijk",
            Agent = vanDijkAgent,
            BirthDate = new DateTime(1991, 07, 08),
            Position = Position.Defender,
            Salary = 80000,
            Contracts = new List<Contract>()
        };
        Player ronaldo = new Player
        {
            Name = "Cristiano Ronaldo",
            Agent = mendes,
            BirthDate = new DateTime(1985, 02, 05),
            Position = Position.Attacker,
            Salary = 200000,
            Contracts = new List<Contract>()
        };
        Player messi = new Player
        {
            Name = "Lionel Messi",
            Agent = messiAgent,
            BirthDate = new DateTime(1987, 06, 24),
            Position = Position.Attacker,
            Salary = 220000,
            Contracts = new List<Contract>()
        };
        Player ramos = new Player
        {
            Name = "Sergio Ramos",
            Agent = mendes,
            BirthDate = new DateTime(1986, 03, 30),
            Position = Position.Defender,
            Salary = 85000,
            Contracts = new List<Contract>()
        };
        Player deBruyne = new Player
        {
            Name = "Kevin De Bruyne",
            Agent = raiola,
            BirthDate = new DateTime(1991, 06, 28),
            Position = Position.Midfielder,
            Salary = 110000,
            Contracts = new List<Contract>()
        };
        Player neymar = new Player
        {
            Name = "Neymar Jr.",
            Agent = pogba,
            BirthDate = new DateTime(1992, 02, 05),
            Position = Position.Attacker,
            Salary = 190000,
            Contracts = new List<Contract>()
        };
        Player mbappe = new Player
        {
            Name = "Kylian Mbappé",
            Agent = mendy,
            BirthDate = new DateTime(1998, 12, 20),
            Position = Position.Attacker,
            Salary = 180000,
            Contracts = new List<Contract>()
        };
        Player lewandowski = new Player
        {
            Name = "Robert Lewandowski",
            Agent = mendes,
            BirthDate = new DateTime(1988, 08, 21),
            Position = Position.Attacker,
            Salary = 160000,
            Contracts = new List<Contract>()
        };
        Player mane = new Player
        {
            Name = "Sadio Mane",
            Agent = raiola,
            BirthDate = new DateTime(1992, 04, 10),
            Position = Position.Attacker,
            Salary = 150000,
            Contracts = new List<Contract>()
        };
        Player salah = new Player
        {
            Name = "Mohamed Salah",
            Agent = raiola,
            BirthDate = new DateTime(1992, 06, 15),
            Position = Position.Attacker,
            Salary = 160000,
            Contracts = new List<Contract>()
        };
        Player kimmich = new Player
        {
            Name = "Joshua Kimmich",
            Agent = mendes,
            BirthDate = new DateTime(1995, 02, 08),
            Position = Position.Midfielder,
            Salary = 120000,
            Contracts = new List<Contract>()
        };
        Player kroos = new Player
        {
            Name = "Toni Kroos",
            Agent = mendes,
            BirthDate = new DateTime(1990, 01, 04),
            Position = Position.Midfielder,
            Salary = 110000,
            Contracts = new List<Contract>()
        };
        Player koulibaly = new Player
        {
            Name = "Kalidou Koulibaly",
            Agent = koulibalyAgent,
            BirthDate = new DateTime(1991, 06, 20),
            Position = Position.Defender,
            Salary = 75000,
            Contracts = new List<Contract>()
        };
        Player marquinhos = new Player
        {
            Name = "Marquinhos",
            Agent = marquinhosAgent,
            BirthDate = new DateTime(1994, 05, 14),
            Position = Position.Defender,
            Salary = 80000,
            Contracts = new List<Contract>()
        };
        Player alisson = new Player
        {
            Name = "Alisson Becker",
            Agent = alissonAgent,
            BirthDate = new DateTime(1992, 10, 02),
            Position = Position.Keeper,
            Salary = 85000,
            Contracts = new List<Contract>()
        };
        Player ederson = new Player
        {
            Name = "Ederson Moraes",
            Agent = mendes,
            BirthDate = new DateTime(1993, 08, 17),
            Position = Position.Keeper,
            Salary = 80000,
            Contracts = new List<Contract>()
        };
        Player oblak = new Player
        {
            Name = "Jan Oblak",
            Agent = oblakAgent,
            BirthDate = new DateTime(1993, 01, 07),
            Position = Position.Keeper,
            Salary = 90000,
            Contracts = new List<Contract>()
        };
        
        barcelona.Contracts.Add(new Contract
        {
            Player = lewandowski,
            Team = barcelona,
            StartDate = new DateTime(2014, 07, 01),
            EndDate = new DateTime(2018, 06, 30)
        });
        barcelona.Contracts.Add(new Contract
        {
            Player = messi,
            Team = barcelona,
            StartDate = new DateTime(2004, 07, 01),
            EndDate = new DateTime(2021, 06, 30)
        });
        barcelona.Contracts.Add(new Contract
        {
            Player = neymar,
            Team = barcelona,
            StartDate = new DateTime(2013, 06, 03),
            EndDate = new DateTime(2017, 08, 03)
        });
        bayern.Contracts.Add(new Contract
        {
            Player = lewandowski,
            Team = bayern,
            StartDate = new DateTime(2018, 07, 01),
            EndDate = new DateTime(2023, 06, 30)
        });
        bayern.Contracts.Add(new Contract
        {
            Player = kimmich,
            Team = bayern,
            StartDate = new DateTime(2015, 07, 01),
            EndDate = new DateTime(2023, 06, 30)
        });
        bayern.Contracts.Add(new Contract
        {
            Player = kroos,
            Team = bayern,
            StartDate = new DateTime(2006, 07, 01),
            EndDate = new DateTime(2014, 07, 14)
        });
        madrid.Contracts.Add(new Contract
        {
            Player = courtois,
            Team = madrid,
            StartDate = new DateTime(2018, 08, 09),
            EndDate = new DateTime(2023, 06, 30)
        });
        madrid.Contracts.Add(new Contract
        {
            Player = modric,
            Team = madrid,
            StartDate = new DateTime(2012, 08, 27),
            EndDate = new DateTime(2024, 06, 30)
        });
        madrid.Contracts.Add(new Contract
        {
            Player = ronaldo,
            Team = madrid,
            StartDate = new DateTime(2009, 07, 01),
            EndDate = new DateTime(2018, 06, 30)
        });
        madrid.Contracts.Add(new Contract
        {
            Player = ramos,
            Team = madrid,
            StartDate = new DateTime(2005, 08, 31),
            EndDate = new DateTime(2021, 06, 30)
        });
        city.Contracts.Add(new Contract
        {
            Player = deBruyne,
            Team = city,
            StartDate = new DateTime(2015, 08, 30),
            EndDate = new DateTime(2023, 06, 30)
        });
        city.Contracts.Add(new Contract
        {
            Player = ederson,
            Team = city,
            StartDate = new DateTime(2017, 07, 01),
            EndDate = new DateTime(2025, 06, 30)
        });
        liverpool.Contracts.Add(new Contract
        {
            Player = vanDijk,
            Team = liverpool,
            StartDate = new DateTime(2018, 07, 01),
            EndDate = new DateTime(2023, 06, 30)
        });
        liverpool.Contracts.Add(new Contract
        {
            Player = mane,
            Team = liverpool,
            StartDate = new DateTime(2016, 06, 28),
            EndDate = new DateTime(2023, 06, 30)
        });
        liverpool.Contracts.Add(new Contract
        {
            Player = salah,
            Team = liverpool,
            StartDate = new DateTime(2017, 07, 01),
            EndDate = new DateTime(2023, 06, 30)
        });
        psg.Contracts.Add(new Contract
        {
            Player = neymar,
            Team = psg,
            StartDate = new DateTime(2017, 08, 03),
            EndDate = new DateTime(2022, 06, 30)
        });
        psg.Contracts.Add(new Contract
        {
            Player = mbappe,
            Team = psg,
            StartDate = new DateTime(2017, 08, 31),
            EndDate = new DateTime(2022, 06, 30)
        });
        psg.Contracts.Add(new Contract
        {
            Player = marquinhos,
            Team = psg,
            StartDate = new DateTime(2013, 07, 19),
            EndDate = new DateTime(2024, 06, 30)
        });
        psg.Contracts.Add(new Contract
        {
            Player = ramos,
            Team = psg,
            StartDate = new DateTime(2021, 07, 01),
            EndDate = new DateTime(2023, 06, 30)
        });
        city.Contracts.Add(new Contract
        {
            Player = doku,
            Team = city,
            StartDate = new DateTime(2015, 08, 30),
            EndDate = new DateTime(2023, 06, 30)
        });
        atletico.Contracts.Add(new Contract
        {
            Player = oblak,
            Team = atletico,
            StartDate = new DateTime(2014, 07, 16),
            EndDate = new DateTime(2023, 06, 30)
        });
        atletico.Contracts.Add(new Contract
        {
            Player = courtois,
            Team = atletico,
            StartDate = new DateTime(2011, 07, 16),
            EndDate = new DateTime(2014, 06, 30)
                });
        
        napoli.Contracts.Add(new Contract
        {
            Player = koulibaly,
            Team = napoli,
            StartDate = new DateTime(2014, 07, 02),
            EndDate = new DateTime(2023, 06, 30)
        });
        liverpool.Contracts.Add(new Contract
        {
            Player = alisson,
            Team = liverpool,
            StartDate = new DateTime(2018, 07, 19),
            EndDate = new DateTime(2027, 06, 30)
        });
        leverkusen.Contracts.Add(new Contract
        {
            Player = kroos,
            Team = leverkusen,
            StartDate = new DateTime(2007, 07, 01),
            EndDate = new DateTime(2010, 07, 01)
        });
        roma.Contracts.Add(new Contract
        {
            Player = marquinhos,
            Team = roma,
            StartDate = new DateTime(2012, 07, 19),
            EndDate = new DateTime(2013, 07, 19)
        });
        roma.Contracts.Add(new Contract
        {
            Player = salah,
            Team = roma,
            StartDate = new DateTime(2015, 08, 03),
            EndDate = new DateTime(2016, 07, 01)
        });
        madrid.Contracts.Add(new Contract
        {
            Player = kroos,
            Team = madrid,
            StartDate = new DateTime(2014, 07, 17),
            EndDate = new DateTime(2023, 06, 30)
            });
        context.Players.Add(doku);
        context.Players.Add(courtois);
        context.Players.Add(modric);
        context.Players.Add(vanDijk);
        context.Players.Add(ronaldo);
        context.Players.Add(messi);
        context.Players.Add(ramos);
        context.Players.Add(deBruyne);
        context.Players.Add(neymar);
        context.Players.Add(mbappe);
        context.Players.Add(lewandowski);
        context.Players.Add(mane);
        context.Players.Add(salah);
        context.Players.Add(kimmich);
        context.Players.Add(kroos);
        context.Players.Add(koulibaly);
        context.Players.Add(marquinhos);
        context.Players.Add(alisson);
        context.Players.Add(ederson);
        context.Players.Add(oblak);
        context.Teams.Add(barcelona);
        context.Teams.Add(madrid);
        context.Teams.Add(city);
        context.Teams.Add(liverpool);
        context.Teams.Add(psg);
        context.Teams.Add(bayern);
        context.Teams.Add(leverkusen);
        context.Teams.Add(roma);
        context.Teams.Add(atletico);
        context.Teams.Add(napoli);
        context.Agents.Add(raiola);
        context.Agents.Add(mendes);
        context.Agents.Add(pogba);
        context.Agents.Add(mendy);
        context.Agents.Add(koulibalyAgent);
        context.Agents.Add(marquinhosAgent);
        context.Agents.Add(alissonAgent);
        context.Agents.Add(mendes);
        context.Agents.Add(oblakAgent);
        context.Agents.Add(dokuAgent);
        context.Agents.Add(courtoisAgent);
        context.Agents.Add(modricAgent);
        context.Agents.Add(vanDijkAgent);
        context.Agents.Add(messiAgent);
        
        
        
        context.SaveChanges();
        context.ChangeTracker.Clear();

    }
}