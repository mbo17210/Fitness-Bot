using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.TextCommands.Parsing;

namespace FitnessBot.Commands;

internal static class CommandSetup {
    private static readonly string[] ALLOWED_PREFIXES = ["&", "?"];
    private static readonly Type[] COMMAND_CLASSES = [];
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