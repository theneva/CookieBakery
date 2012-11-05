namespace CookieBakery
{
    /*
     * Not bothering with a Customer class because of the project's tiny scope.
     * 
     * Second most useless class ever.
     */
    class Person
    {
        public readonly string Name;

        // No nameless people around here
        private Person()
        {
        }

        public Person(string name)
        {
            this.Name = name;
        }
    }
}
