/*
	Copyright (c) 2011 Christopher A. Taylor.  All rights reserved.

	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:

	* Redistributions of source code must retain the above copyright notice,
	  this list of conditions and the following disclaimer.
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	* Neither the name of LibCat nor the names of its contributors may be used
	  to endorse or promote products derived from this software without
	  specific prior written permission.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
	ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
	LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
	CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
	SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
	INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
	ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
	POSSIBILITY OF SUCH DAMAGE.
*/

#ifndef CAT_SINGLY_LINKED_LISTS_HPP
#define CAT_SINGLY_LINKED_LISTS_HPP

#include <cat/Platform.hpp>

// The point of this code is to generate fast and correct implementations of
// linked lists that introduce a minimal amount of overhead.

namespace cat {

	
/*
	Forward-only singly linked list

	Macros for correct implementation of a linked list,
	where the next/prev variables are members of the objects in
	the list.  The names of the next/prev member variables must
	be provided in the arguments to the macros.

	To iterate through the list, use code like this:

		for (Node *item = head; item; item = item->next)

	Can insert at the head of the list, pushing the previous head
	down the list.

	Can erase an item in the list given a pointer to the item.

	Operations are all O(1).
	Not thread-safe.
*/

/*
	Clear the list without releasing memory, useful for startup.

	head: Pointer to the head of the list
*/
#define CAT_FSLL_CLEAR(head)	\
{								\
	head = 0;					\
}

/*
	Push object to the front of the list.

	head: Pointer to the head of the list
	obj: Pointer to object that will be inserted at front
	next: Name of member variable pointer to next list item
	prev: Name of member variable pointer to previous list item
*/
#define CAT_FSLL_PUSH_FRONT(head, obj, next, prev)	\
{													\
	(obj)->next = head;								\
	head = obj;										\
}

/*
	Insert an item directly after another item.

	head: Pointer to the head of the list
	obj: Pointer to object that will be inserted after another item
	another: List item that will be before the inserted item
	next: Name of member variable pointer to next list item
	prev: Name of member variable pointer to previous list item
*/
#define CAT_FSLL_INSERT_AFTER(head, obj, another, next, prev)	\
{																\
	(obj)->next = (another)->next;								\
	(another)->next = obj;										\
}

/*
	Erase object from the list, does not release memory.

	head: Pointer to the head of the list
	obj: Pointer to object that will be erased after another item
	another: Pointer to object before the item to be erased, or 0 for head
	next: Name of member variable pointer to next list item
	prev: Name of member variable pointer to previous list item
*/
#define CAT_FSLL_ERASE_AFTER(head, obj, another, next, prev)	\
{																\
	if (another)	(another)->next = (obj)->next;				\
	else			head = (obj)->next;							\
}


/*
	Derive singly-linked list items from this base class
	to wrap using the macros above.
*/
class SListItem
{
	friend class SList;
	friend class SListIteratorBase;

private:
	SListItem *_next;
};


// Internal class
class SListIteratorBase
{
	friend class SList;

protected:
	SListItem *_item, *_prev;

	CAT_INLINE void IterateNext()
	{
		_prev = _item;
		_item = _item->_next;
	}
};


/*
	Access the linked list through this type.
*/
class SList
{
	SListItem *_head;

public:
	SList();

	CAT_INLINE SListItem *head() { return _head; }

	void PushFront(SListItem *item);
	void InsertAfter(SListItem *item, SListItem *at);
	void EraseAfter(SListItem *item, SListItem *at);

	// Erase via iterator to simplify usage
	CAT_INLINE void Erase(SListIteratorBase *iterator)
	{
		EraseAfter(iterator->_item, iterator->_prev);
	}

	/*
		When iterating forward through the list,
		use the following mechanism:

		for (SList::Iterator<MyObject> ii = list.head(); ii; ++ii)
	*/
	template<class T>
	class Iterator : public SListIteratorBase
	{
		CAT_INLINE Iterator() {}

	public:
		CAT_INLINE Iterator(SListItem *item)
		{
			_prev = 0;
			_item = item;
		}

		CAT_INLINE Iterator &operator=(SListItem *item)
		{
			_prev = 0;
			_item = item;
			return *this;
		}

		CAT_INLINE operator T *()
		{
			return static_cast<T*>( _item );
		}

		CAT_INLINE T *operator->()
		{
			return static_cast<T*>( _item );
		}

		CAT_INLINE T *GetPrevious()
		{
			return static_cast<T*>( _prev );
		}

		CAT_INLINE Iterator &operator++() // pre-increment
		{
			IterateNext();
			return *this;
		}

		CAT_INLINE Iterator &operator++(int) // post-increment
		{
			IterateNext();
			return *this;
		}
	};
};


} // namespace cat

#endif // CAT_SINGLY_LINKED_LISTS_HPP