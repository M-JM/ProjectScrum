using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MielsJimmyScrumProjectDAL.Context;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BoardRepository> _logger;

        public BoardRepository(AppDbContext context,ILogger<BoardRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Board Create(Board board)
        {
            try
            {
                if (board != null)
                {
                    var newBoardEntityEntry = _context.Boards.Add(board);

                    if (newBoardEntityEntry != null &&
                        newBoardEntityEntry.State == EntityState.Added)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The board {board.Name} is created.");
                            return newBoardEntityEntry.Entity;
                        }
                    }
                }

                _logger.LogWarning($"The Board given is Null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When creating a board Failed.");
                throw;
            }
        }

        public Board Delete(Board board)
        {
            try
            {
            
                if (board != null)
                {
                    var DeletedBoardEntityEntry = _context.Boards.Update(board);

                    if (DeletedBoardEntityEntry != null &&
                        DeletedBoardEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The board {board.Name} is deleted.");
                            return DeletedBoardEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogWarning($"The Board given is Null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When deleting a board Failed.");
                throw;
            }
        }

        public IEnumerable<Board> GetAllBoards()
        {
            var listBoards = _context.Boards.Include( x => x.BoardUsers).Where( x => x.IsDeleted == false).Include(x => x.BoardTasks);
            return listBoards;
        }

        public IEnumerable<Board> GetAllBoardsfromcompany(int? id)
        {
            var listBoardsOfCompany = _context.Boards
                .Include(x => x.BoardTasks)
                .Where(u => u.IsDeleted == false)
                .Include(x => x.BoardUsers)
                .Where(x => x.CompanyId == id && x.IsDeleted == false);
                //.Include(x => x.BoardUsers.All(x => x.ApplicationUser.IsDeleted == false);
            
            return listBoardsOfCompany;
        }

        public Board GetById(int id)
        {

            // board met bepaald ID en boardusers maar virtual applicationuser is null
            var board = _context.Boards
                .Include(x => x.BoardUsers)
                .Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();               

            return board;
        }

        public IEnumerable<BoardUser> GetUsersofBoard(int id)
        {
                        
            var test = _context.BoardUsers.Include(x => x.ApplicationUser)
                .Where(x => x.BoardId == id && x.IsDeleted == false).ToList();

            //var testing = _context.BoardUsers.Include(x => x.ApplicationUser)
            //    .Where(x => x.ApplicationUserId == userId);
            //var NEWTEST = _context.BoardUsers
            //    .Include(x => x.ApplicationUser)
            //    .Include(x => x.Board)
            //    .Where(x => x.BoardId == id && x.IsDeleted == false && x.ApplicationUser.IsDeleted == false).ToList();


            return test;
        }

        public IEnumerable<BoardUser> GetBoardsOfUser(string id)
        {

            var test = _context.BoardUsers.Where(x => x.ApplicationUser.Id == id && x.IsDeleted == false).ToList();

            //var testing = _context.BoardUsers.Include(x => x.ApplicationUser)
            //    .Where(x => x.ApplicationUserId == userId);
            //var NEWTEST = _context.BoardUsers
            //    .Include(x => x.ApplicationUser)
            //    .Include(x => x.Board)
            //    .Where(x => x.BoardId == id && x.IsDeleted == false && x.ApplicationUser.IsDeleted == false).ToList();


            return test;
        }


        public Board Update(Board board)
        {
            try
            {
                if (board != null)
                {
                    var updateBoardEntityEntry = _context.Boards.Update(board);

                    if (updateBoardEntityEntry != null &&
                        updateBoardEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The board {board.Name} is updated.");
                            return updateBoardEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogWarning($"The Board given is Null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When updating a board Failed.");
                throw;
            }
        }

        public BoardUser AssignBoardUser(BoardUser boardUser)
        {
            try
            {
              
                {
                    var newBoardUserEntityEntry = _context.BoardUsers.Add(boardUser);

                    if (newBoardUserEntityEntry != null &&
                        newBoardUserEntityEntry.State == EntityState.Added)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {boardUser.ApplicationUser} was added to {boardUser.Board.Name}.");
                            return newBoardUserEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogWarning($"The board or user was null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When adding user to board.");
                throw;
            }
        }

        public BoardUser UpdateBoardUser(BoardUser boardUser)
        {
            try
            {

                {
                    var updateBoardUserEntityEntry = _context.BoardUsers.Update(boardUser);

                    if (updateBoardUserEntityEntry != null &&
                        updateBoardUserEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {boardUser.ApplicationUser} was modified to {boardUser.Board.Name}.");
                            return updateBoardUserEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogWarning($"The board or user was null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When adding user to board.");
                throw;
            }
        }

        public BoardUser FindBoardUser(int boardid , string userid)
        {
            var exists = _context.BoardUsers.FirstOrDefault(x => x.BoardId == boardid && x.ApplicationUserId == userid);

            return exists;
        }

        public BoardUser RemoveBoardUser(BoardUser boardUser)
        {
            try
            {

                {
                    
                    var removeBoardUserEntityEntry = _context.BoardUsers.Update(boardUser);

                    if (removeBoardUserEntityEntry != null &&
                        removeBoardUserEntityEntry.State == EntityState.Modified)
                    {

                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {boardUser.ApplicationUser} was set to false from {boardUser.Board.Name}.");
                            return removeBoardUserEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogWarning($"The board or user was null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When setting user to false from {boardUser.Board.Name}.");
                throw;
            }
        }

        public BoardUser FindBoardUserById(int boardid, string userid)
        {
            BoardUser existingboarduser = _context.BoardUsers.FirstOrDefault(x => x.BoardId == boardid && x.ApplicationUserId == userid);

            return existingboarduser;
        }
    }
}
