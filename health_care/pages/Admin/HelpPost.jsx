import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import AdminNav from './AdminNav'
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';

const HelpPost = () => {
  const router = useRouter();
  const [allHelppost, setAllHelppost] = useState([]);
  const [error, setError] = useState('');
  const { user, login, logout, Tkey } = useAuth() || {}; 

  useEffect(() => {
    // Fetch products when the component mounts
    GetHelppost();
  }, []);

  const GetHelppost = async () => {
    try {
      const response = await axios.get(
        'https://localhost:44307/api/helppost/GetAllHelpPosts',
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
        console.log('Products:', response.data);
        console.log(response.data);
        setAllHelppost(response.data);
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
  };

  const handleEditClick = (product) => {

    router.push({
        pathname: '/Manager/EditLandPost',
        query: {
          landid: product.landid,
          landname: product.landname,
          price: product.price,
          description: product.description,
        },
      });
      
  };

  const handleDeleteClick = async (landid) => {
    console.log(`Delete clicked for product with ID: ${landid}`);
    try {
      const respons = await axios.delete(`http://localhost:7000/manager/deleteland/${landid}`);

      GetLandpost();
      if (respons.data.success) {
        console.log('Product deleted successfully');
        
        // Update the UI state to remove the deleted product
        setAllLandpost(prevProducts => prevProducts.filter(product => product.landid !== landid));
      } else {
        
        console.log('Failed to delete product');
        
        setError('Failed to delete product');
      }
    } catch (error) {
      console.error('Delete failed:', error);
      setError(`An error occurred while deleting the product: ${error.message}`);
    }
  };
  
  return (
    <div>
      <SessionCheck />
    <AdminNav />
  
    <div className="bg-gray-200 text-white min-h-screen pr-8 pl-8 shadow-md">
      <div className="container mx-auto">
        <h2 className="text-3xl font-bold mb-2 text-center text-gray-700">Manage Help Post</h2>
  
        <div className="mt-4 overflow-x-auto">
          <table className="min-w-full border border-collapse rounded-md overflow-hidden">
            <thead>
              <tr className="bg-[#192a56] text-white">
                <th className="py-2 px-4 border">Name</th>
                <th className="py-2 px-4 border">Phone</th>
                <th className="py-2 px-4 border">Location</th>
                <th className="py-2 px-4 border">Problems</th>
                <th className="py-2 px-4 border">Amount</th>
                <th className="py-2 px-4 border">Actions</th>
              </tr>
            </thead>
            <tbody className="bg-gray-100 text-gray-700 text-center">
              {allHelppost.length > 0 ? (
                allHelppost.map((product) => (
                  <tr key={product.HelpPostId}>
                    <td className="py-2 px-4 border">{product.Name}</td>
                    <td className="py-2 px-4 border">{product.Phone}</td>
                    <td className="py-2 px-4 border">{product.Location}</td>
                    <td className="py-2 px-4 border">{product.Problems}</td>
                    <td className="py-2 px-4 border">{product.Amount} TK</td>
                    <td className="py-2 px-4 border space-x-2">
                      <button
                        className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer"
                        onClick={() => handleEditClick(product.landid)}
                      >
                        Accept
                      </button>
                      <button
                        className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer"
                        onClick={() => handleDeleteClick(product.landid)}
                      >
                        Reject
                      </button>
                    </td>
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="6" className="py-4 px-4 border">
                    {error || 'No products available'}
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
  
  );
};

export default HelpPost















// ManagerDashboard.jsx




   