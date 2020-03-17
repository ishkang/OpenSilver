

/*===================================================================================
* 
*   Copyright (c) Userware/OpenSilver.net
*      
*   This file is part of the OpenSilver Runtime (https://opensilver.net), which is
*   licensed under the MIT license: https://opensource.org/licenses/MIT
*   
*   As stated in the MIT license, "the above copyright notice and this permission
*   notice shall be included in all copies or substantial portions of the Software."
*  
\*====================================================================================*/


#if WORKINPROGRESS

using System.Collections;               // IComparer
using System.Collections.ObjectModel;   // ObservableCollection
using System.Collections.Specialized;   // NotifyCollectionChangedEvent*
using System.Diagnostics;
using System.Globalization;             // CultureInfo

namespace System.ComponentModel
{
    /// <summary>
    /// Base class for group descriptions.
    /// A GroupDescription describes how to divide the items in a collection
    /// into groups.
    /// </summary>
    public abstract partial class GroupDescription : INotifyPropertyChanged
    {
        #region Constructors

        //------------------------------------------------------
        //
        //  Constructors
        //
        //------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of GroupDescription.
        /// </summary>
        protected GroupDescription()
        {
            this._explicitGroupNames = new ObservableCollection<object>();
            this._explicitGroupNames.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnGroupNamesChanged);
        }

        #endregion Constructors

        #region INotifyPropertyChanged

        /// <summary>
        ///     This event is raised when a property of the group description has changed.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                this.PropertyChanged += value;
            }
            remove
            {
                this.PropertyChanged -= value;
            }
        }

        /// <summary>
        /// PropertyChanged event (per <see cref="INotifyPropertyChanged" />).
        /// </summary>
        protected virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A subclass can call this method to raise the PropertyChanged event.
        /// </summary>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        #endregion INotifyPropertyChanged

        #region Public Properties

        //------------------------------------------------------
        //
        //  Public Properties
        //
        //------------------------------------------------------

        /// <summary>
        /// This list of names is used to initialize a group with a set of
        /// subgroups with the given names.  (Additional subgroups may be
        /// added later, if there are items that don't match any of the names.)
        /// </summary>
        public ObservableCollection<object> GroupNames
        {
            get
            {
                return this._explicitGroupNames;
            }
        }

        /// <summary>
        /// This method is used by TypeDescriptor to determine if this property should
        /// be serialized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGroupNames()
        {
            return (this._explicitGroupNames.Count > 0);
        }

        /// <summary>
        /// Collection of Sort criteria to sort the groups.
        /// </summary>
        public SortDescriptionCollection SortDescriptions
        {
            get
            {
                if (this._sort == null)
                {
                    this.SetSortDescriptions(new SortDescriptionCollection());
                }
                return this._sort;
            }
        }

        /// <summary>
        /// This method is used by TypeDescriptor to determine if this property should
        /// be serialized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSortDescriptions()
        {
            return (this._sort != null && this._sort.Count > 0);
        }

        /// <summary>
        /// Set a custom comparer to sort groups using an object that implements IComparer.
        /// </summary>
        /// <remarks>
        /// Note: Setting the custom comparer object will clear previously set <seealso cref="GroupDescription.SortDescriptions"/>.
        /// </remarks>
        public IComparer CustomSort
        {
            get
            {
                return this._customSort;
            }
            set
            {
                this._customSort = value;
                this.SetSortDescriptions(null);
                this.OnPropertyChanged(new PropertyChangedEventArgs("CustomSort"));
            }
        }

        #endregion Public Properties

        #region Public Methods

        //------------------------------------------------------
        //
        //  Public Methods
        //
        //------------------------------------------------------

        /// <summary>
        /// Return the group name(s) for the given item
        /// </summary>
        public abstract object GroupNameFromItem(object item, int level, CultureInfo culture);

        /// <summary>
        /// Return true if the names match (i.e the item should belong to the group).
        /// </summary>
        public virtual bool NamesMatch(object groupName, object itemName)
        {
            return Equals(groupName, itemName);
        }

        #endregion Public Methods

        #region Internal Properties

        //------------------------------------------------------
        //
        //  Internal Properties
        //
        //------------------------------------------------------

        /// <summary>
        /// Collection of Sort criteria to sort the groups.  Does not do lazy initialization.
        /// </summary>
        internal SortDescriptionCollection SortDescriptionsInternal
        {
            get
            {
                return this._sort;
            }
        }

        #endregion Internal Properties

        #region Private Methods

        //------------------------------------------------------
        //
        //  Private Methods
        //
        //------------------------------------------------------

        private void OnGroupNamesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("GroupNames"));
        }

        // set new SortDescription collection; rehook collection change notification handler
        private void SetSortDescriptions(SortDescriptionCollection descriptions)
        {
            if (this._sort != null)
            {
                ((INotifyCollectionChanged)this._sort).CollectionChanged -= new NotifyCollectionChangedEventHandler(SortDescriptionsChanged);
            }

            bool raiseChangeEvent = (_sort != descriptions);

            this._sort = descriptions;

            if (this._sort != null)
            {
                Debug.Assert(_sort.Count == 0, "must be empty SortDescription collection");
                ((INotifyCollectionChanged)this._sort).CollectionChanged += new NotifyCollectionChangedEventHandler(SortDescriptionsChanged);
            }

            if (raiseChangeEvent)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs("SortDescriptions"));
            }
        }

        // SortDescription was added/removed, notify listeners
        private void SortDescriptionsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // adding to SortDescriptions overrides custom sort
            if (this._sort.Count > 0)
            {
                if (this._customSort != null)
                {
                    this._customSort = null;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomSort"));
                }
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("SortDescriptions"));
        }


        #endregion Private Methods

        #region Private fields

        //------------------------------------------------------
        //
        //  Private fields
        //
        //------------------------------------------------------

        private ObservableCollection<object> _explicitGroupNames;
        private SortDescriptionCollection _sort;
        private IComparer _customSort;

        #endregion Private fields
    }
}

#endif