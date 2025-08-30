using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace RoslynScripting
{
    public class Script<TGlobals> where TGlobals : 
        class, ISupportsCancellation
    {
        private ScriptState<TGlobals> _scriptState;

        private TGlobals _globals;

        public static async Task<Script<TGlobals>> Create(
            IEnumerable<Assembly> references,
            IEnumerable<string> usings,
            TGlobals globals)
        {
            var options = ScriptOptions.Default
                .WithReferences(references)
                .WithImports(usings);

            var state = await CSharpScript
                .RunAsync<TGlobals>("", options, globals);

            return new Script<TGlobals> 
            { 
                _scriptState = state, 
                _globals = globals 
            };
        }

        public async Task ExecuteNext(
            string code, CancellationToken token)
        {
            _globals.CancellationRequest = token;

            await Task.Run(
                async () =>
                {
                    await _scriptState.ContinueWithAsync(
                        code, null, token
                        );
                }
            );

            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException(token);
            }
        }
    }
}
