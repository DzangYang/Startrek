namespace Shared.Core;

public enum Permission
{
   AccessMember = 1,
   ReadMember = 2,
   DeletionMember = 3,
   TaskMember = 4,
   UpdateMember = 5,
   /// <summary>
   /// Разрешение на чтение данных
   /// </summary>
   Admin_ReadMember = 501,
   /// <summary>
   /// Разрешение на создание данных
   /// </summary>
   Admin_TaskMember = 502,
   /// <summary>
   /// Разрешение на обновление данных
   /// </summary>
   Admin_UpdateMember = 503,
   /// <summary>
   /// Разрешение на удаление данных
   /// </summary>
   Admin_DeletionMember = 504,
   
   HR_AddCandidates = 610,
   HR_GetAllCandidates = 611,
   HR_GetByIdCandidate = 612,
   HR_GetByFilterCandidate = 613,
   HR_RemoveCandidate = 614,
   HR_UpdateCandidate = 615,
   
   HR_AddInterview = 620,
   HR_RelocateInterview = 621,
   HR_CancellInterview = 622,
   HR_ConductInterview = 623,
   HR_GetAllInterviews = 624,
   HR_GetByIdInterview = 625,
   
   
   HR_AddOffer = 630,
   HR_IssuanceOffer = 631,
   HR_RevokeOffer = 632,
   HR_ApplyOffer = 633,
   HR_GetAllOffers = 634,
   HR_GetByIdOffer = 635,
 
   HR_AddVacancy = 640,
   HR_UpdateVacancy = 641,
   HR_BindVacancy = 642,
   HR_GetByIdVacancy = 643,
   HR_GetAllVacancies = 644,
   HR_RemoveVacancy = 645,
 
   
}