namespace WebHousingAssociation.Services
{
    public class AssociationInfoService
    {
        //TODO: Lav logikken
        public Task<string> GetAssociationInfo(string AssociationId)
        {
            //Lav logik for at hente info fra Entity Framework
            string associationInfo = "Virksomhedens navn, adresse, telefonnummer, email, CVR-nummer osv.";
            return Task.FromResult(associationInfo);
        }
    }
}
