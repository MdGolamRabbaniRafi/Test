import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
import UserNav from './UserNav';
import SessionCheck from '../Session';


const EditPost = () => {
  const router = useRouter();
  const { PostId, Name, Problems } = router.query;
  const [name, setname] = useState(Name || '');
  const [problems, setproblems] = useState(Problems || '');
  const [error, setError] = useState('');
  const [formErrors, setFormErrors] = useState({});

  useEffect(() => {
    const fetchProductDetails = async () => {
      try {
        const response = await axios.get(`https://localhost:44307/api/post/${PostId}`);
        console.log("respons" +response.data)
        console.log("success" + response.data.success)
        if (response.data.success) {
          const productDetails = response.data.data;
          setname(productDetails.name);
          setproblems(productDetails.Problems);
        } else {
          
        }
      } catch (error) {
        
      }
    };

    fetchProductDetails();
  }, [PostId]);

  const handleNameChange = (e) => {
    setname(e.target.value);
  };

  const handleProblemsChange = (e) => {
    setproblems(e.target.value);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name || !problems) {
      setError('Please enter both product name and price');
    } else {
      try {
        const response = await axios.post(
          `https://localhost:44307/api/post/update/${PostId}`,
          {
            Name: name,
            Problems: problems,
          },
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );

        if (response.data.success) {
          console.log('Post updated successfully');
         
        } else {
            router.push('/User/UserPost');
          setError('Failed to update post');
        }
      } catch (error) {
        console.error('Update failed:', error);
        setError(`An error occurred while updating the post: ${error.message}`);
      }
    }
  };

  return (
    <div>
     <SessionCheck />
      <UserNav />
    <div className="flex justify-center items-center h-screen bg-gray-100">
      <div className="bg-white p-8 rounded shadow-md w-96">
        <h2 className="text-2xl font-bold mb-6">EDIT POST</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-6">
            <label htmlFor="product" className="block text-sm font-semibold text-gray-600 mb-1">
              Name:
            </label>
            <input
              type="text"
              id="name"
              name="name"
              value={name}
              onChange={handleNameChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.name ? 'border-red-500' : 'border-gray-300'
              }`}
            />
            {formErrors.name && <p className="text-red-500 text-sm mt-1">{formErrors.name}</p>}
          </div>
          <div className="mb-6">
            <label htmlFor="product_price" className="block text-sm font-semibold text-gray-600 mb-1">
              Problems:
            </label>
            <input
              type="text"
              id="problems"
              name="problems"
              value={problems}
              onChange={handleProblemsChange}
              className={`w-full p-3 border rounded-md focus:outline-none ${
                formErrors.problems ? 'border-red-500' : 'border-gray-300'
              }`}
            />
            {formErrors.problems && (
              <p className="text-red-500 text-sm mt-1">{formErrors.problems}</p>
            )}
          </div>
          <button
            type="submit"
            className="bg-blue-500 text-white align-middle px-4 py-2 rounded-full hover:bg-blue-600 transition duration-300"
          >
            EDIT
          </button>
        </form>
        {error && <p className="text-red-500 mt-4">{error}</p>}
      </div>
    </div>
    </div>
  );
};

export default EditPost;
