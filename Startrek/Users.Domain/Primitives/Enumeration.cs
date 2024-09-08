using System.Reflection;

namespace Users.Domain.Primitives;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
   where TEnum : Enumeration<TEnum>
{
   private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();
   
   public int Id { get; protected init; }
   public string Name { get; protected init; } = string.Empty;

   protected Enumeration(int id, string name)
   {
      Id = id;
      Name = name;
   }
   public static TEnum? FromId(int id)
   {
      return Enumerations.TryGetValue(
         id,
         out TEnum? enumeration)
         ? enumeration
         : default;
   }

   public static TEnum? FromName(string name)
   {
      return Enumerations
         .Values
         .SingleOrDefault(e => e.Name == name);
   }

   public static IReadOnlyCollection<TEnum> GetValues() => Enumerations.Values.ToList();
   private static Dictionary<int, TEnum> CreateEnumerations()
   {
      var enumerationType = typeof(TEnum);

      var fieldsForType = enumerationType
         .GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy)
         .Where(fieldsInfo =>
            enumerationType.IsAssignableFrom(fieldsInfo.FieldType))
         .Select(fieldInfo =>
            (TEnum)fieldInfo.GetValue(default)!);
      
      return fieldsForType.ToDictionary(x => x.Id);
   }
   public bool Equals(Enumeration<TEnum>? other)
   {
      if (other == null)
      {
         return false;
      }
      
      return GetType() == other.GetType() && Id  == other.Id;
   }

   public override bool Equals(object? obj)
   {
      return obj is Enumeration<TEnum> other && Equals(other);
   }

   public override string ToString()
   {
      return Name;
   }

   public override int GetHashCode()
   {
      return Id.GetHashCode();
   }
}