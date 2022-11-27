using System.Collections.ObjectModel;

namespace Common;

public class CoordinateMap<TMappedObject> : KeyedCollection<Coordinate, TMappedObject>
    where TMappedObject : IMappedObject
{
    protected override Coordinate GetKeyForItem(TMappedObject item)
    {
        return item.Coordinate;
    }
}
