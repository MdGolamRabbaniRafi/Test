import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import ServiceProviderNav from './ServiceProviderNav'
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';


const AcceptDonateMoney = () => {
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
        'https://localhost:44307/api/ServiceProvider/PendingRequests',
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
        console.log("isapproved" + response.data.IsApproved); 
        setAllHelppost(response.data);
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`No Request`);
    }
  };

  const handleEditClick = async(Id) => {
    try {
      const response = await axios.post(
        `https://localhost:44307/api/ServiceProvider/ApproveDonation/${Id}`,
        {
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `${Tkey}`,
          },
        }
      );
       
      if (response.data) {
        console.log('Products:', response.data);
        GetHelppost();
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
    
   
  };
  
  const handleDeleteClick = async (Id) => {
  
    try {
      const respons = await axios.post(`https://localhost:44307/api/ServiceProvider/DeleteDonation/${Id}`);

      GetHelppost();
      if (respons.data.success) {
        console.log('Product deleted successfully');
        
        // Update the UI state to remove the deleted product
        setAllHelppost(prevProducts => prevProducts.filter(product => product.Id !== Id));
      } else {
        
        console.log('');
        
       
      }
    } catch (error) {
      console.error('Delete failed:', error);
      setError(`An error occurred while deleting the product: ${error.message}`);
    }
  };
  
  return (
    <div>
      <SessionCheck />
    <ServiceProviderNav />
  
    <div className="bg-gray-200 text-white min-h-screen pr-8 pl-8 shadow-md">
      <div className="container mx-auto">
        <h2 className="text-3xl font-bold mb-2 text-center text-gray-700">Manage Help Post</h2>
  
        <div className="mt-4 overflow-x-auto">
          <table className="min-w-full border border-collapse rounded-md overflow-hidden">
            <thead>
              <tr className="bg-[#192a56] text-white">
                <th className="py-2 px-4 border">UserId</th>
                <th className="py-2 px-4 border">Amount</th>
                <th className="py-2 px-4 border">Description</th>
                <th className="py-2 px-4 border">IsApproved</th>
                <th className="py-2 px-4 border">CreateAt</th>
                <th className="py-2 px-4 border">ApprovedAt</th>
                <th className="py-2 px-4 border">IsPaid</th>
                <th className="py-2 px-4 border">Action</th>
              </tr>
            </thead>
            <tbody className="bg-gray-100 text-gray-700 text-center">
              {allHelppost.length > 0 ? (
                allHelppost.map((product) => (
                  <tr key={product.Id}>
                    <td className="py-2 px-4 border">{product.UserId}</td>
                    <td className="py-2 px-4 border">{product.Amount} TK</td>
                    <td className="py-2 px-4 border">{product.Description}</td>
                    <td className="py-2 px-4 border"> {product.IsApproved === false ? "Pending" : product.IsApproved}</td>
                    <td className="py-2 px-4 border">{product.CreatedAt} </td>
                    <td className="py-2 px-4 border"> {product.ApprovedAt === null ? "Not Approve" : product.ApprovedAt}
                    </td>                    
                    <td className="py-2 px-4 border">{product.IsPaid === false ? "Pending" : product.IsPaid} </td>
                    <td className="py-2 px-4 border space-x-2">
                      <button
                        className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer"
                        onClick={() => handleEditClick(product.Id)}
                      >
                        Accept
                      </button>
                      <button
                        className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer"
                        onClick={() => handleDeleteClick(product.Id)}
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

export default AcceptDonateMoney