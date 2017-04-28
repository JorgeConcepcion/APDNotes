using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace APDNotes.Models
{
    public class AWSS3Manager
    {

        string s3Bucket;
        AmazonS3Client Client;
        public AWSS3Manager(string s3Bucket)
        {
            this.S3Bucket = s3Bucket;
            Client = new AmazonS3Client();
        }

        public void UploadFile(string fileKey, string PCfilePath)
        {
            PutObjectRequest request = new PutObjectRequest();
            request.BucketName = this.S3Bucket;
            request.Key = fileKey;
            request.FilePath = PCfilePath;
            Client.PutObject(request);

        }
        public void GetFile(string fileKey, string PCfilePath)
        {
            GetObjectRequest request = new GetObjectRequest();
            request.BucketName = this.S3Bucket;
            request.Key = fileKey;
            GetObjectResponse response = Client.GetObject(request);
            response.WriteResponseStreamToFile(PCfilePath);
        }

        public string S3Bucket
        {
            get { return s3Bucket; }
            set { s3Bucket = value; }
        }
    }
}