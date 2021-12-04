using EFNet5.Data;
using EFNet5.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFNet5.ConsoleApp
{
    internal class Program
    {
        private static FootballLeagueDbContext context = new FootballLeagueDbContext();

        static async Task Main(string[] args)
        {
            #region Insertion Crud

            //// Pour l'Insertion (Create Crud)

            //// 1. Avec création de la jointure via l'ID

            // var league = new League { Name = "League A" };
            // await context.Leagues.AddAsync(league);
            // await context.SaveChangesAsync(); 
            //// L'Id de la league est ici alimenté par la requète
            // var team = new Team { Name = Team A", LeagueId = league.Id };
            // await context.Teams.AddAsync(team);
            // await context.SaveChangesAsync();

            //// 2. Avec création de la jointure via la propriété de navigation

            // var league = new League { Name = "League B" };
            // await context.Leagues.AddAsync(league);
            // await context.SaveChangesAsync();
            // var team = new Team { Name = Team B", League = league }; 
            //// On passe ici l'objet, et EF se sert de la proriété de navigation pour alimenter la requête SQL
            // await context.Teams.AddAsync(team);
            // await context.SaveChangesAsync();

            //// 3. L'ordre importe peu, EF Core modifie l'ordre des requêtes pour éviter les erreurs

            // var league = new League { Name = "League C" };
            // await context.AddAsync(league);
            // var team = new Team { Name = Team C", League = league }; 
            // await context.Teams.AddAsync(team);
            // await context.AddAsync(team);
            // await context.SaveChangesAsync();
            //// L'ordre des requête est ici géré pour éviter de ne pas avoir de Foreign Key dans l'objet team

            #endregion

            #region Selection cRud

            //// Pour la selection (Read cRud)

            //// 1. Selection simple

            //// Le ToList() permet de faire une nouvelle référence à la série afin de ne pas monopoliser la connexion pour raison de performances
            //var leagues = await context.Leagues.ToListAsync(); 
            //leagues.ForEach(l => Console.WriteLine($"{l.Id} - {l.Name}"));

            //// 2. Selection filtrée

            //Console.Write("Enter League Name (Or part of): ");
            //var leagueName = Console.ReadLine();

            //// a. On utilise l'égalité

            //// Va ici utiliser l'égalité en SQL
            //var exactMatches = await context.Leagues.Where(l => l.Name.Equals(leagueName)).ToListAsync(); 
            //exactMatches.ForEach(l => Console.WriteLine($"{l.Id} - {l.Name}"));

            //// b. On laisse EF Core décider de la fonction la plus adaptée 

            //// Va ici utiliser le LIKE du SQL de façon automatique
            //var partialMatches = await context.Leagues.Where(l => l.Name.Contains(leagueName)).ToListAsync(); 
            //partialMatches.ForEach(l => Console.WriteLine($"{l.Id} - {l.Name}"));

            //// c. On spécifie nous même la fonction SQL à utiliser 

            //// On force ici l'utilisation du LIKE du SQL
            //var functionMatches = await context.Leagues.Where(l => EF.Functions.Like(l.Name, $"%{leagueName}%")).ToListAsync(); 
            //functionMatches.ForEach(l => Console.WriteLine($"{l.Id} - {l.Name}"));

            #endregion

            #region Méthodes d'exécution supplémentaires

            //var leagues = context.Leagues;

            //// Pour tranformer le HashSet en List avec IEnumerable
            //var list = await leagues.ToListAsync();

            //// Pour obtenir le premier (Exception si jamais il n'y a rien à récupéré)
            //var first = await leagues.FirstAsync();

            //// Pour obtenir le premier (default() - en gros null, si jamais il n'y a rien à récupérer)
            //var firstOrDefault = await leagues.FirstOrDefaultAsync();

            //// Pour obtenir un seul élement (Exception si jamais aucun / plus d'un élement match)
            //var single = await leagues.SingleAsync(l => l.Name.Equals("Serie A"));

            //// Pour obtenir un seul élement (default() - en gros null, si jamais aucun / plus d'un élement match)
            //var singleOrDefault = await leagues.SingleOrDefaultAsync(l => l.Name.Equals("Serie A"));

            //// Renvoie le nombre d'éléments sous forme d'Int32
            //var count = await leagues.CountAsync();

            //// Renvoie le nombre d'éléments sous forme de Long
            //var longCount = await leagues.LongCountAsync();

            //// Renvoie le minimum des élements de la table
            //var min = await leagues.MinAsync(l => l.Id);

            //// Renvoie le maximum des élements de la table
            //var max = await leagues.MaxAsync(l => l.Id);

            //// Trouve l'élément recherché via sa clé primaire
            //var league = await leagues.FindAsync(1);

            #endregion

            #region Syntaxes Linq Alternatives

            //// Cette syntaxe ressemble plus au SQL classique tout en restant du C#
            //var teams = from x in context.Teams select x;
            //// x peut être ce qu'on veut, tout comme dans le cas d'une expression lambda
            //var teams2 = await (from x in context.Teams select x).ToListAsync();
            //// On ne peut pas faire de .ForEach() si ce n'est pas un IEnumerable (ici teams est un IQueryable, mais teams2 est une List, donc hérite de IEnumerable)

            //// Avec ajout d'un filtre

            //var teams3 = from x in context.Teams where x.Name.Contains("A") select x;
            //// On laisse EF Core gérer la fonction SQL
            //var teams4 = from x in context.Teams where EF.Functions.Like(x.Name, "A") select x;
            //// On spécifie la fonction SQL à utiliser

            #endregion

            #region Modification crUd

            //// Pour la modification (Update crUd)

            //// 1. Récupération des données
            //var league = await context.Leagues.FindAsync(1);
            //Console.WriteLine($"{league.Id} - {league.Name}");


            //// 2. Modification des données
            //league.Name = "League Modified";

            //// 3. Sauvegarde des modifications
            //await context.SaveChangesAsync();
            //// Si la modification n'en est pas une car déjà effectuée, alors la requête n'a pas lieu

            //// 4. Vérification de la modification
            //var leagueModified = await context.Leagues.FindAsync(1);
            //Console.WriteLine($"{leagueModified.Id} - {leagueModified.Name}");

            //// EF Core peut aussi modifier un élement existant si on envoie un nouvel élement ayant la même ID (ou l'ajouter si l'ID n'est pas spécifié dans l'objet)
            //// En cas d'ID incorrect car non existant, une exception est levée

            //var team = new Team
            //{
            //    Id = 9,
            //    Name = "Team C",
            //    LeagueId = 2,
            //};

            //context.Teams.Update(team);
            //await context.SaveChangesAsync();


            #endregion

            #region Suppression cruD

            //// Pour la suppresion (Delete cruD)

            //// 1. Suppression simple

            //var leagueToRemove = await context.Leagues.FindAsync(4);
            //context.Leagues.Remove(leagueToRemove);
            //await context.SaveChangesAsync();

            ////context.Leagues.RemoveRange();
            //// Attention à bien spécifier les entités à supprimer sous peine de supprimer toute la table

            //// 2. Suppression avec relation (Suppression en cascade provenant des propriétés des contraintes de FK lors de la génération de la migration initiale, celle créant la BdD)
            //var leagueToRemove = await context.Leagues.FindAsync(5);
            //context.Leagues.Remove(leagueToRemove);
            //await context.SaveChangesAsync();
            //// Cela va supprimer toutes les Team ayant comme League leagueToRemove de façon automatique

            #endregion

            #region Le Tracking

            //var withTracking = await context.Teams.FirstOrDefaultAsync(t => t.Id == 9);
            //var withoutTracking = await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == 9);
            //// Améliore les performance pour les grandes quantités de données à traquer en libérant cette fonctionnalité

            //withTracking.Name = "Team D";
            //withoutTracking.Name = "Team E";
            //// L'update n'aura pas lieu sauf si on spécifie manuellement via la méthode Update(), car non traquée

            //var entreiesBeforeSave = context.ChangeTracker.Entries();
            //// Nous montre les entités traquées
            //// Ici une seule entité est marquée comme Modified (c'est une Enum de State)

            //await context.SaveChangesAsync();

            //var entriesAfterSave = context.ChangeTracker.Entries();
            //// L'entité est passée en State Unchanged

            #endregion

            Console.ReadKey();
        }
    }
}
