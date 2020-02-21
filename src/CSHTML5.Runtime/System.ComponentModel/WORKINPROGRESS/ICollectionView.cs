#if WORKINPROGRESS

namespace System.ComponentModel
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Globalization;
    //
    // Summary:
    //     Enables collections to have the functionalities of current record management,
    //     custom sorting, filtering, and grouping.
    public interface ICollectionView : IEnumerable, INotifyCollectionChanged
    {
        //
        // Summary:
        //     Gets a value that indicates whether this view supports filtering by way of the
        //     System.ComponentModel.ICollectionView.Filter property.
        //
        // Returns:
        //     true if this view supports filtering; otherwise, false.
        bool CanFilter { get; }
        //
        // Summary:
        //     Gets a value that indicates whether this view supports grouping by way of the
        //     System.ComponentModel.ICollectionView.GroupDescriptions property.
        //
        // Returns:
        //     true if this view supports grouping; otherwise, false.
        bool CanGroup { get; }
        //
        // Summary:
        //     Gets a value that indicates whether this view supports sorting by way of the
        //     System.ComponentModel.ICollectionView.SortDescriptions property.
        //
        // Returns:
        //     true if this view supports sorting; otherwise, false.
        bool CanSort { get; }
        //
        // Summary:
        //     Gets or sets the cultural information for any operations of the view that may
        //     differ by culture, such as sorting.
        //
        // Returns:
        //     The culture information to use during culture-sensitive operations.
        CultureInfo Culture { get; set; }
        //
        // Summary:
        //     Gets the current item in the view.
        //
        // Returns:
        //     The current item in the view or null if there is no current item.
        object CurrentItem { get; }
        //
        // Summary:
        //     Gets the ordinal position of the System.ComponentModel.ICollectionView.CurrentItem
        //     in the view.
        //
        // Returns:
        //     The ordinal position of the System.ComponentModel.ICollectionView.CurrentItem
        //     in the view.
        int CurrentPosition { get; }
        //
        // Summary:
        //     Gets or sets a callback that is used to determine whether an item is appropriate
        //     for inclusion in the view.
        //
        // Returns:
        //     A method that is used to determine whether an item is appropriate for inclusion
        //     in the view.
        Predicate<object> Filter { get; set; }
        //
        // Summary:
        //     Gets a collection of System.ComponentModel.GroupDescription objects that describe
        //     how the items in the collection are grouped in the view.
        //
        // Returns:
        //     A collection of objects that describe how the items in the collection are grouped
        //     in the view.
        ObservableCollection<GroupDescription> GroupDescriptions { get; }
        //
        // Summary:
        //     Gets the top-level groups.
        //
        // Returns:
        //     A read-only collection of the top-level groups or null if there are no groups.
        ReadOnlyObservableCollection<object> Groups { get; }
        //
        // Summary:
        //     Gets a value that indicates whether the System.ComponentModel.ICollectionView.CurrentItem
        //     of the view is beyond the end of the collection.
        //
        // Returns:
        //     true if the System.ComponentModel.ICollectionView.CurrentItem of the view is
        //     beyond the end of the collection; otherwise, false.
        bool IsCurrentAfterLast { get; }
        //
        // Summary:
        //     Gets a value that indicates whether the System.ComponentModel.ICollectionView.CurrentItem
        //     of the view is beyond the start of the collection.
        //
        // Returns:
        //     true if the System.ComponentModel.ICollectionView.CurrentItem of the view is
        //     beyond the start of the collection; otherwise, false.
        bool IsCurrentBeforeFirst { get; }
        //
        // Summary:
        //     Gets a value that indicates whether the view is empty.
        //
        // Returns:
        //     true if the view is empty; otherwise, false.
        bool IsEmpty { get; }
        //
        // Summary:
        //     Gets a collection of System.ComponentModel.SortDescription instances that describe
        //     how the items in the collection are sorted in the view.
        //
        // Returns:
        //     A collection of values that describe how the items in the collection are sorted
        //     in the view.
        SortDescriptionCollection SortDescriptions { get; }
        //
        // Summary:
        //     Gets the underlying collection.
        //
        // Returns:
        //     The underlying collection.
        IEnumerable SourceCollection { get; }

        //
        // Summary:
        //     Occurs after the current item has been changed.
        event EventHandler CurrentChanged;
        //
        // Summary:
        //     Occurs before the current item changes.
        event CurrentChangingEventHandler CurrentChanging;

        //
        // Summary:
        //     Indicates whether the specified item belongs to this collection view.
        //
        // Parameters:
        //   item:
        //     The object to check.
        //
        // Returns:
        //     true if the item belongs to this collection view; otherwise, false.
        bool Contains(object item);
        //
        // Summary:
        //     Enters a defer cycle that you can use to merge changes to the view and delay
        //     automatic refresh.
        //
        // Returns:
        //     The typical usage is to create a using scope with an implementation of this method
        //     and then include multiple view-changing calls within the scope. The implementation
        //     should delay automatic refresh until after the using scope exits.
        IDisposable DeferRefresh();
        //
        // Summary:
        //     Sets the specified item in the view as the System.ComponentModel.ICollectionView.CurrentItem.
        //
        // Parameters:
        //   item:
        //     The item to set as the current item.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentTo(object item);
        //
        // Summary:
        //     Sets the first item in the view as the System.ComponentModel.ICollectionView.CurrentItem.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentToFirst();
        //
        // Summary:
        //     Sets the last item in the view as the System.ComponentModel.ICollectionView.CurrentItem.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentToLast();
        //
        // Summary:
        //     Sets the item after the System.ComponentModel.ICollectionView.CurrentItem in
        //     the view as the System.ComponentModel.ICollectionView.CurrentItem.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentToNext();
        //
        // Summary:
        //     Sets the item at the specified index to be the System.ComponentModel.ICollectionView.CurrentItem
        //     in the view.
        //
        // Parameters:
        //   position:
        //     The index to set the System.ComponentModel.ICollectionView.CurrentItem to.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentToPosition(int position);
        //
        // Summary:
        //     Sets the item before the System.ComponentModel.ICollectionView.CurrentItem in
        //     the view to the System.ComponentModel.ICollectionView.CurrentItem.
        //
        // Returns:
        //     true if the resulting System.ComponentModel.ICollectionView.CurrentItem is an
        //     item in the view; otherwise, false.
        bool MoveCurrentToPrevious();
        //
        // Summary:
        //     Recreates the view.
        void Refresh();
    }
}

#if CSHTML5
namespace System.Collections.ObjectModel
{
    using System.Collections.Specialized;
    using System.ComponentModel;

    public class ReadOnlyObservableCollection<T> : ReadOnlyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.ObjectModel.ReadOnlyObservableCollection`1
        //     class that serves as a wrapper for the specified System.Collections.ObjectModel.ObservableCollection`1.
        //
        // Parameters:
        //   list:
        //     The collection to wrap.
        public ReadOnlyObservableCollection(ObservableCollection<T> list) : base(list)
        {

        }

        //
        // Summary:
        //     Occurs when an item is added or removed.
        protected event NotifyCollectionChangedEventHandler CollectionChanged;
        //
        // Summary:
        //     Occurs when a property value changes.
        protected event PropertyChangedEventHandler PropertyChanged;

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Raises the System.Collections.ObjectModel.ReadOnlyObservableCollection`1.CollectionChanged
        //     event.
        //
        // Parameters:
        //   args:
        //     The event data.
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {

        }
        //
        // Summary:
        //     Raises the System.Collections.ObjectModel.ReadOnlyObservableCollection`1.PropertyChanged
        //     event.
        //
        // Parameters:
        //   args:
        //     The event data.
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {

        }
    }
}
#endif

namespace System.ComponentModel
{
    //
    // Summary:
    //     Represents a method that can handle the System.ComponentModel.ICollectionView.CurrentChanging
    //     event of an System.ComponentModel.ICollectionView implementation.
    //
    // Parameters:
    //   sender:
    //     The source of the event.
    //
    //   e:
    //     The event data.
    public delegate void CurrentChangingEventHandler(object sender, CurrentChangingEventArgs e);
}

namespace System.ComponentModel
{
    //
    // Summary:
    //     Provides data for the System.ComponentModel.ICollectionView.CurrentChanging event.
    public class CurrentChangingEventArgs : EventArgs
    {
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.CurrentChangingEventArgs
        //     class and sets the System.ComponentModel.CurrentChangingEventArgs.IsCancelable
        //     property to true.
        public CurrentChangingEventArgs()
        {

        }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.CurrentChangingEventArgs
        //     class and sets the System.ComponentModel.CurrentChangingEventArgs.IsCancelable
        //     property to the specified value.
        //
        // Parameters:
        //   isCancelable:
        //     true to disable the ability to cancel a System.ComponentModel.ICollectionView.CurrentItem
        //     change; false to enable cancellation.
        public CurrentChangingEventArgs(bool isCancelable)
        {

        }

        //
        // Summary:
        //     Gets or sets a value that indicates whether the System.ComponentModel.ICollectionView.CurrentItem
        //     change should be canceled.
        //
        // Returns:
        //     true if the event should be canceled; otherwise, false. The default is false.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.ComponentModel.CurrentChangingEventArgs.IsCancelable property value
        //     is false.
        public bool Cancel { get; set; }
        //
        // Summary:
        //     Gets a value that indicates whether the System.ComponentModel.ICollectionView.CurrentItem
        //     change can be canceled.
        //
        // Returns:
        //     true if the event can be canceled; false if the event cannot be canceled.
        public bool IsCancelable { get; }
    }
}

namespace System.ComponentModel
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    //
    // Summary:
    //     Represents a collection of System.ComponentModel.SortDescription instances.
    public class SortDescriptionCollection : Collection<SortDescription>, INotifyCollectionChanged
    {
        //
        // Summary:
        //     Gets an empty and non-modifiable System.ComponentModel.SortDescriptionCollection.
        public static readonly SortDescriptionCollection Empty;

        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.SortDescriptionCollection
        //     class.
        public SortDescriptionCollection()
        {

        }

        //
        // Summary:
        //     Occurs when a System.ComponentModel.SortDescription is added or removed.
        protected event NotifyCollectionChangedEventHandler CollectionChanged;

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Removes all System.ComponentModel.SortDescription instances from the collection.
        protected override void ClearItems()
        {

        }
        //
        // Summary:
        //     Inserts a System.ComponentModel.SortDescription into the collection at the specified
        //     index.
        //
        // Parameters:
        //   index:
        //     The zero-based index where the System.ComponentModel.SortDescription is inserted.
        //
        //   item:
        //     The System.ComponentModel.SortDescription to insert.
        protected override void InsertItem(int index, SortDescription item)
        {

        }
        //
        // Summary:
        //     Removes the System.ComponentModel.SortDescription at the specified index in the
        //     collection.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the System.ComponentModel.SortDescription to remove.
        protected override void RemoveItem(int index)
        {

        }
        //
        // Summary:
        //     Replaces the System.ComponentModel.SortDescription at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the System.ComponentModel.SortDescription to replace.
        //
        //   item:
        //     The new value for the System.ComponentModel.SortDescription at the specified
        //     index.
        protected override void SetItem(int index, SortDescription item)
        {

        }
    }
}

namespace System.ComponentModel
{
    //
    // Summary:
    //     Defines the direction and the property name that will be used as the criteria
    //     for sorting a collection.
    public struct SortDescription
    {
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.SortDescription structure.
        //
        // Parameters:
        //   propertyName:
        //     The name of the property to sort the list by.
        //
        //   direction:
        //     The sort order.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The propertyName parameter is null.
        //
        //   T:System.ArgumentException:
        //     The propertyName parameter is empty.-or-The direction parameter does not specify
        //     a valid value.
        public SortDescription(string propertyName, ListSortDirection direction)
        {
            this.IsSealed = true;
            this.PropertyName = propertyName;
            this.Direction = direction;
        }

        //
        // Summary:
        //     Gets or sets a value that indicates whether to sort in ascending or descending
        //     order.
        //
        // Returns:
        //     A value that indicates the sort direction.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.ComponentModel.SortDescription.IsSealed is true.
        //
        //   T:System.ArgumentException:
        //     The specified value is not a valid sort direction.
        public ListSortDirection Direction { get; set; }
        //
        // Summary:
        //     Gets a value that indicates whether this structure is in an immutable state.
        //
        // Returns:
        //     true if this object is being used; otherwise, false.
        public bool IsSealed { get; }
        //
        // Summary:
        //     Gets or sets the property name being used as the sorting criteria.
        //
        // Returns:
        //     The name of the property to sort by.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.ComponentModel.SortDescription.IsSealed is true.
        public string PropertyName { get; set; }

        //
        // Summary:
        //     Compares the specified instance and the current instance of System.ComponentModel.SortDescription
        //     for value equality.
        //
        // Parameters:
        //   obj:
        //     The System.ComponentModel.SortDescription instance to compare.
        //
        // Returns:
        //     true if obj and this System.ComponentModel.SortDescription instance have the
        //     same System.ComponentModel.SortDescription.PropertyName and System.ComponentModel.SortDescription.Direction
        //     values; otherwise, false.
        public override bool Equals(object obj)
        {
            return false;
        }
        //
        // Summary:
        //     Returns the hash code for the current instance.
        //
        // Returns:
        //     The hash code for the current instance.
        public override int GetHashCode()
        {
            return 0;
        }

        //
        // Summary:
        //     Compares two System.ComponentModel.SortDescription instances for value equality.
        //
        // Parameters:
        //   sd1:
        //     The first System.ComponentModel.SortDescription instance to compare.
        //
        //   sd2:
        //     The second System.ComponentModel.SortDescription instance to compare.
        //
        // Returns:
        //     true if the two System.ComponentModel.SortDescription instances have the same
        //     System.ComponentModel.SortDescription.PropertyName and System.ComponentModel.SortDescription.Direction
        //     values; otherwise, false.
        public static bool operator ==(SortDescription sd1, SortDescription sd2)
        {
            return false;
        }
        //
        // Summary:
        //     Compares two System.ComponentModel.SortDescription instances for value inequality.
        //
        // Parameters:
        //   sd1:
        //     The first System.ComponentModel.SortDescription instance to compare.
        //
        //   sd2:
        //     The second System.ComponentModel.SortDescription instance to compare.
        //
        // Returns:
        //     true if the two System.ComponentModel.SortDescription instances do not have the
        //     same System.ComponentModel.SortDescription.PropertyName and System.ComponentModel.SortDescription.Direction
        //     values; otherwise, false.
        public static bool operator !=(SortDescription sd1, SortDescription sd2)
        {
            return false;
        }
    }
}

#endif