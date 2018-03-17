﻿using System;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO
{
    public class CommandInterpreter
    {
        private readonly Tester _judge;
        private readonly StudentsRepository _repository;
        private readonly IOManager _inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            _judge = judge;
            _repository = repository;
            _inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            var data = input.Split();
            var commandName = data[0];
            try
            {
                var command = ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        //Directs command IF is valid
        private Command ParseCommand(string input, string[] data, string command)
        {
            switch (command.ToLower())
            {
                case "open":
                    return new OpenFileCommand(input, data, _judge, _repository, _inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, _judge, _repository, _inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, _judge, _repository, _inputOutputManager);
                case "cmd":
                    return new CompareFilesCommand(input, data, _judge, _repository, _inputOutputManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, _judge, _repository, _inputOutputManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, _judge, _repository, _inputOutputManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, _judge, _repository, _inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, _judge, _repository, _inputOutputManager);
                case "show":
                    return new ShowCourseCommand(input, data, _judge, _repository, _inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, _judge, _repository, _inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, _judge, _repository, _inputOutputManager);
                case "decorder":
                    throw new NotImplementedException();
                case "download":
                    throw new NotImplementedException();
                case "downloadasynch":
                    throw new NotImplementedException();
                case "dropdb":
                    return new DropDatabaseCommand(input, data, _judge, _repository, _inputOutputManager);
            }

            throw new InvalidCommandException(input);
        }
    }
}