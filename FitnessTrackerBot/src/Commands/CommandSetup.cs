using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.TextCommands.Parsing;

namespace FitnessTrackerBot.Commands;

internal static class CommandSetup {
    private static readonly string[] ALLOWED_PREFIXES = ["&", "?"];
    private static readonly Type[] COMMAND_CLASSES = [typeof(ScheduleCommands), typeof(SetupCommands)];
    public static void Configure(IServiceProvider serviceProvider, CommandsExtension extension)
    {
        extension.AddCommands(COMMAND_CLASSES);

        TextCommandProcessor textCommandProcessor = new(new() 
        {
            PrefixResolver = new DefaultPrefixResolver(true, ALLOWED_PREFIXES).ResolvePrefixAsync,
        });
        extension.AddProcessor(textCommandProcessor);
    }
}