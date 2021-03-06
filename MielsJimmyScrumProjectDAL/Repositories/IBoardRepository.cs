﻿using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public interface IBoardRepository
    {

        // READ
        Board GetById(int id);

        IEnumerable<Board> GetAllBoards();

        IEnumerable<Board> GetAllBoardsfromcompany(int? id);

        IEnumerable<BoardUser> GetUsersofBoard(int id);

        IEnumerable<BoardUser> GetBoardsOfUser(string id);

        // CREATE

        Board Create(Board board);

        BoardUser AssignBoardUser(BoardUser boardUser);

        // SOFT DELETE

        Board Delete(Board board);

        BoardUser RemoveBoardUser(BoardUser boardUser);

        // UPDATE

        Board Update(Board board);
        BoardUser UpdateBoardUser(BoardUser boardUser);

        BoardUser FindBoardUser(int boardid, string userid);

        BoardUser FindBoardUserById(int boardid, string userid);

    }
}
