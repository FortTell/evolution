namespace Evolution.Logic
{
    public struct CreatureCommand
    {
        public int dx;
        public int dy;

        public override string ToString()
        {
            return "dx: " + dx + ", dy: " + dy;
        }
    }
}
