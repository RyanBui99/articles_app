import React from 'react';
import NavbarComponent from '../../components/NavbarComponent';
import Grid from '@mui/material/Grid';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getBlogPosts } from '../../store/actionCreators/blogPostCreator';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import BlogPosts from '../../components/BlogPosts';

export default function BlogPage() {
  const { blogPosts } = useTypedSelector((state) => state.blogPosts);
  const dispatch = useDispatch();

  React.useEffect(() => {
    dispatch(getBlogPosts());
  }, [dispatch]);

  return (
    <>
      <NavbarComponent />
      <Grid
        justifyContent='center'
        sx={{ flexGrow: 1 }}
        container
        spacing={3}
        marginTop='2em'
      >
        {blogPosts.map((blogPost: IStorageBlogPosts, key: number) => (
          <Grid key={key} item>
            <BlogPosts blogPost={blogPost} />
          </Grid>
        ))}
      </Grid>
    </>
  );
}
