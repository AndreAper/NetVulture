using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nvcore.Devices;

namespace nvcore.ManagementClasses
{
    public class DeviceCollection : ICollection<IDevice>
    {
        private List<IDevice> innerCol;

        /// <summary>
        /// Get the count of elements of <see cref="DeviceCollection"/> instance.
        /// </summary>
        public int Count => this.innerCol.Count();

        /// <summary>
        /// Return that the <see cref="DeviceCollection"/> instance is only readable.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a new device to the <see cref="DeviceCollection"/> instance.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IDevice item)
        {
            if (!Contains(item))
            {
                innerCol.Add(item);
            }
            else
            {
                throw new Exception($"Element with target address {item.PrimaryTargetAddress} already exist in this collection.");
            }
        }

        /// <summary>
        /// Add a device to the <see cref="DeviceCollection"/> instance.
        /// </summary>
        /// <param name="index">The specific index to add the device.</param>
        /// <returns>The device at the index.</returns>
        public IDevice this[int index]
        {
            get => (IDevice)innerCol[index];
            set => innerCol[index] = value;
        }

        /// <summary>
        /// Removes all items from the <see cref="DeviceCollection"/> instance.
        /// </summary>
        public void Clear()
        {
            this.innerCol.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="DeviceCollection"/> contains a specific device.
        /// </summary>
        /// <param name="item">The device to locate in the <see cref="DeviceCollection"/>.</param>
        /// <returns>true if item is found in the <see cref="DeviceCollection"/>; otherwise, false.</returns>
        public bool Contains(IDevice item)
        {
            return this.innerCol.Contains(item);
        }

        /// <summary>
        /// Determines whether the <see cref="DeviceCollection"/> contains a specific device using primary target address.
        /// </summary>
        /// <param name="primaryTarget">The primary target address to locate in the <see cref="DeviceCollection"/>.</param>
        /// <returns>true if item is found in the <see cref="DeviceCollection"/>; otherwise, false.</returns>
        public bool Contains(string primaryTarget)
        {
            return this.innerCol.Any(x => x.PrimaryTargetAddress == primaryTarget);
        }

        /// <summary>
        /// Copies the elements of the <see cref="DeviceCollection"/> to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="DeviceCollection"/>. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(IDevice[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i + arrayIndex] = innerCol[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DeviceCollection"/>.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="DeviceCollection"/>.</returns>
        public IEnumerator<IDevice> GetEnumerator()
        {
            return this.innerCol.GetEnumerator();
        }

        /// <summary>
        /// Remove a device from the device collection.
        /// </summary>
        /// <param name="item">The device to remove.</param>
        public void Remove(IDevice item)
        {
            if (Contains(item))
            {
                this.innerCol.Remove(item);
            }
            else
            {
                throw new Exception(string.Format("Element with target address {0} is not exist in this collection.", item.PrimaryTargetAddress));
            }
        }

        /// <summary>
        /// Remove a device with specific primary address from the device collection.
        /// </summary>
        /// <param name="primaryTarget">The device with specific primary address to remove.</param>
        public void Remove(string primaryTarget)
        {
            if (Contains(primaryTarget))
            {
                IDevice idc = this.innerCol.Single(x => x.PrimaryTargetAddress == primaryTarget);
                this.innerCol.Remove(idc); 
            }
            else
            {
                throw new Exception(string.Format("Element with target address {0} is not exist in this collection.", primaryTarget));
            }
        }

        /// <summary>
        /// Remove a number of device from the device collection.
        /// </summary>
        /// <param name="index">The start index to start.</param>
        /// <param name="count">The count of elements to remove.</param>
        public void RemoveRange(int index, int count)
        {
            this.innerCol.RemoveRange(index, count);
        }


        /// <summary>
        /// Remove all device with specific device type.
        /// </summary>
        /// <param name="type">The type of device to remove from the <see cref="DeviceCollection"/>.</param>
        public void RemoveType(DeviceTypes type)
        {
            if (this.innerCol.Any(x => x.DeviceType == type))
            {
                foreach (IDevice idc in this.innerCol.Where(x => x.DeviceType == type))
                {
                    this.innerCol.Remove(idc);
                } 
            }
        }

        bool ICollection<IDevice>.Remove(IDevice item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new instance of <see cref="DeviceCollection"/>.
        /// </summary>
        public DeviceCollection()
        {
            innerCol = new List<IDevice>();
        }
    }
}
