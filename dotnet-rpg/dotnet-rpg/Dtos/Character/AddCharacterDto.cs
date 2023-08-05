namespace dotnet_rpg.Dtos.Character
{
    public class AddCharacterDto
    {
        /* When we add a character, we don't want to give it an ID
         * Instead, let the database assign ID
         * Change return type in service
         */
        public required string Name { get; set; }
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;

    }
}
