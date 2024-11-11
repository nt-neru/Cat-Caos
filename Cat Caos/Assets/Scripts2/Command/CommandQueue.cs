using System.Collections.Generic;

// Logica para ejecutar los comandos en fila
public class CommandQueue // Como no depende de MonoBehavior no se destruye al cambiar de escena
{
    private static CommandQueue instance;
    private Queue<ICommand> commandsQueue = new Queue<ICommand>();
    private bool runningCommand = false;
    // Constructor privado para evitar instanciación externa
    private CommandQueue() { }
    // Propiedad estática para obtener la instancia del Singleton
    public static CommandQueue Instance => instance ?? (instance = new CommandQueue());

    // Añade un comando a la fila
    public void AddCommand(ICommand commandToExecute)
    {
        commandsQueue.Enqueue(commandToExecute);
        RunNextCommand();
    }

    // Revisando el siguiente comando a ejecutar
    public void RunNextCommand()
    {
        if(runningCommand){
            return;
        }
        while (commandsQueue.Count > 0)
        {
            runningCommand = true;
            var commandToExecute = commandsQueue.Dequeue();
            commandToExecute.Execute();
        }
        runningCommand = false;
    }
}
