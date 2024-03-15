import UserNav from './UserNav'
import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import { FaEdit, FaTrashAlt } from 'react-icons/fa';
import { BsPlus } from 'react-icons/bs';
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';

const UserDashboard = () => {
  const router = useRouter();
  const [allProducts, setAllProducts] = useState([]);
  const [showProfile, setShowProfile] = useState(false);
  const [error, setError] = useState('');
  const [comments, setComments] = useState([]);
  const [newComment, setNewComment] = useState('');
  const { user, login, logout, Tkey } = useAuth() || {}; 

  const handleAddComment = (postId, newComment) => {
    if (newComment.trim() !== '') {
      setComments((prevComments) => [
        ...prevComments,
        { postId, comment: newComment },
      ]);
    }
  };

  useEffect(() => {
    // Fetch products when the component mounts
    GetProducts();
  }, []);

  const GetProducts = async () => {
    try {
      const response = await axios.get(
        'https://localhost:44307/api/post/GetAllPosts',
        {
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `${Tkey}`,
          },
        }
      );
       console.log(response.data)
       console.log(response.success)
      if (response.data) {
        console.log('Post:', response.data);
        console.log(response.data.data);
        setAllProducts(response.data);
      } else {
        console.log('No post available');
        setError('No Post available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`No post Available`);
    }
  };

  const handleEditClick = (product) => {

    router.push({
        pathname: '/User/EditPost',
        query: {
          PostId: product.PostId,
          Name: product.Name,
          Problems: product.Problems,
          
        },
      });
      
  };

  const handleDeleteClick = async (PostId) => {
    console.log(`Delete clicked for product with ID: ${PostId}`);
    try {
      const respons = await axios.delete(`https://localhost:44307/api/post/delete/${PostId}`);

      GetProducts();
      if (respons.data.success) {
        console.log('Post deleted successfully');
        
        // Update the UI state to remove the deleted product
        setAllProducts(prevProducts => prevProducts.filter(product => product.PostId !== PostId));
      } else {
        
        console.log('Failed to delete post');
        
        setError('Failed to delete post');
      }
    } catch (error) {
      console.error('Delete failed:', error);
      setError(`An error occurred while deleting the product: ${error.message}`);
    }
  };
  return (
    <div>
      <SessionCheck />
      
  <UserNav />
  <div className="grid grid-cols-12 pr-8 pl-8 mb-2 mt-0">
  <div className="col-span-12 bg-[#dfe4ea] text-[#192a56]  shadow-md">
    <h1 className="text-3xl font-bold mb-4 text-center">User Dashboard</h1>
    <div className="flex justify-end mt-5">
              {/* Add Post */}
              <Link href="/User/Campaign">
                <div className="flex items-center bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer">
                  <BsPlus className="mr-2" />
                  Join Campaign
                </div>
              </Link>
            </div>
    
    <div className="mt-4">
              {allProducts.length > 0 ? (
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-8 gap-4">
                  {allProducts.map((product) => (
                    <div key={product.PostId} className="w-full md:max-w-md mx-auto bg-white shadow-md rounded-md p-6">
                      <div className="flex items-center mb-4">
                        {/* Display user profile picture (you can replace this with your user image logic) */}
                        <div className="w-10 h-10 bg-gray-400 rounded-full mr-4"></div>
                        <div>
                          <h3 className="text-xl font-bold text-[#192a56]">{product.Name}</h3>
                          <p className="text-gray-500">{/* Add timestamp or date here */}</p>
                        </div>
                      </div>
                      <p className="text-[#192a56] mb-2">{product.Problems}</p>
                      <p className="text-gray-700 mb-2">Blood Group: {product.BloodGroup}</p>
                      <p className="text-gray-700 mb-2">Phone: {product.Phone}</p>
                      <p className="text-gray-700 mb-2">Location: {product.Location}</p>

                      {/* Comment Section */}
                      <div className="mt-4">
                        <h4 className="text-lg font-bold mb-2">Comments</h4>
                        <ul>
                          {comments
                            .filter((comment) => comment.postId === product.PostId)
                            .map((comment, index) => (
                              <li key={index} className="text-gray-700 mb-2">{comment.comment}</li>
                            ))}
                        </ul>
                        <div className="flex items-center mt-2">
                          <textarea
                            value={newComment}
                            onChange={(e) => setNewComment(e.target.value)}
                            className="w-full p-1 border rounded-md text-black"
                            placeholder="Add a comment..."
                          />
                          <button
                            onClick={() => handleAddComment(product.PostId, newComment)}
                            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md ml-2"
                          >
                            Add
                          </button>
                        </div>
                      </div>

                      {/* <div className="flex justify-end items-center mt-4">
                        <button
                          className="text-blue-500 hover:text-blue-600 mr-3"
                          onClick={() => handleEditClick(product)}
                        >
                          <FaEdit />
                        </button>
                        <button
                          className="text-red-500 hover:text-red-600"
                          onClick={() => handleDeleteClick(product.PostId)}
                        >
                          <FaTrashAlt />
                        </button>
                      </div> */}
                    </div>
                  ))}
                </div>
              ) : (
                <div className="text-[#192a56]">{error || 'No products available'}</div>
              )}
            </div>
    </div>

   
    
    
  </div>
</div>


  )
}

export default UserDashboard