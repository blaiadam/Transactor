using Transactor.controllers;

if (args.Length != 1)
{
    Console.WriteLine($"One argument is required");
    return;
}

FileController fileController = new();
fileController.Read(args[0]);

UIController.Start();