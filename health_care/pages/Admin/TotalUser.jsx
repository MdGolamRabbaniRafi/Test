import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { useRouter } from 'next/router';
import AdminNav from './AdminNav'
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';

const TotalUser = () => {
  const router = useRouter();
  const [allHelppost, setAllHelppost] = useState([]);
  const [error, setError] = useState('');
  const { user, login, logout, Tkey } = useAuth() || {};

  useEffect(() => {
    // Fetch products when the component mounts
    GetUser();
  }, []);

  const GetUser = async () => {
    try {
      const response = await axios.get(
        'https://localhost:44307/api/AllUser',
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
                <th className="py-2 px-4 border">Full Name</th>
                <th className="py-2 px-4 border">Email</th>
                <th className="py-2 px-4 border">DOB</th>
                <th className="py-2 px-4 border">BloodGroup</th>
                
              </tr>
            </thead>
            <tbody className="bg-gray-100 text-gray-700 text-center">
              {allHelppost.length > 0 ? (
                allHelppost.map((product) => (
                  <tr key={product.UserId}>
                    <td className="py-2 px-4 border">{product.FirstName}</td>
                    <td className="py-2 px-4 border">{product.Email}</td>
                    <td className="py-2 px-4 border">{product.DateOfBirth}</td>
                    <td className="py-2 px-4 border">{product.BloodGroup}</td>
                   
                    
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


export default TotalUser






















   