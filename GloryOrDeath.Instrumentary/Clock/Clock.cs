namespace GloryOrDeath.Instrumentary.Clock
{
    public class Clock : IDisposable
    {
        private readonly int _interval;

        private int _passed;
        private readonly CancellationToken _token;
        private bool _isDisposed;
        public int Passed => _passed;
        public event Func<Task> Elapsed;


        public Clock(int interval)
        {
            _interval = interval;
            _token = new CancellationToken();
        }

        public async Task StartAsync()
        {
            while (!_token.IsCancellationRequested)
            {
                await Task.Delay(_interval);
                _passed += _interval;
                await Elapsed.Invoke();
            }
        }

        public async Task StopAsync()
        {
            _token.ThrowIfCancellationRequested();
        }

        public void Dispose()
        {
            var invocationList = Elapsed.GetInvocationList();
            foreach (var invocation in invocationList)
            {
                Elapsed -= invocation as Func<Task>;
            }

            _isDisposed = true;
        }
    }
}
