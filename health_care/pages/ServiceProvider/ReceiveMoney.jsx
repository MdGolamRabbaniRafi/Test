import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import ServiceProviderNav from './ServiceProviderNav'
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';

const ReceiveMoney = () => {
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
        'https://localhost:44307/api/ServiceProvider/ApprovedDonations',
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
        setError('No Approve Request');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`No Approve Request`);
    }
  };

 
  
  return (
    <div>
      <SessionCheck />
    <ServiceProviderNav />
  
    <div className="bg-gray-200 text-white min-h-screen pr-8 pl-8 shadow-md">
      <div className="container mx-auto">
        <h2 className="text-3xl font-bold mb-2 text-center text-gray-700">Receive Money</h2>
  
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
                
                
              </tr>
            </thead>
            <tbody className="bg-gray-100 text-gray-700 text-center">
              {allHelppost.length > 0 ? (
                allHelppost.map((product) => (
                  <tr key={product.Id}>
                    <td className="py-2 px-4 border">{product.UserId}</td>
                    <td className="py-2 px-4 border">{product.Amount} TK</td>
                    <td className="py-2 px-4 border">{product.Description}</td>
                    <td className="py-2 px-4 border"> {product.IsApproved === true ? "Approved" : ""}</td>
                    <td className="py-2 px-4 border">{product.CreatedAt} </td>
                    <td className="py-2 px-4 border"> {product.ApprovedAt}
                    </td>                    
                    
                    
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="6" className="py-4 px-4 border">
                    {error || 'No post available'}
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



export default ReceiveMoney





