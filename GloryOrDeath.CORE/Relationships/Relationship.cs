﻿namespace GloryOrDeath.CORE.Relationships
{
    public class Relationship
    {
        public const int MinStage = -10;
        public const int MaxStage = 10;
        public int Stage { get; set; }
        public Relationship(Guid from, Guid to, int stage)
        {
            From = from;
            To = to;
            Stage = stage;
        }

        public void StageUp()
        {
            if (Stage < MaxStage)
                Stage++;
        }

        public void StageDown()
        {
            if (Stage > MinStage)
                Stage--;
        }

        public Guid From { get; set; }
        public Guid To { get; set; }
    }
}
